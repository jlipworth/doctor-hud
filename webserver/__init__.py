import json
import string
import sqlite3
import os
import flask
from datetime import datetime, timedelta
from subprocess import Popen, PIPE
from threading import Lock, Thread
from queue import Queue

import scrypt
from flask import Flask, render_template, redirect, request, session, Response
from flask_sockets import Sockets


DATABASE_FILENAME = os.path.join(
    os.path.dirname(os.path.realpath(__file__)),
    'var', 'database.db'
)

app = Flask(__name__)
# Ensure the server picks up new js changes
app.config['SEND_FILE_MAX_AGE_DEFAULT'] = 0
app.config.from_object('config')
sockets = Sockets(app)

connections_lock = Lock()
connections = {}
openice_proc_started = False


def enqueue_to_sockets(data):
    data_str = json.dumps(data)
    with connections_lock:
        for q in connections.values():
            q.put(data_str)
    # print("done sending", data_str)


def openice_proc():
    with connections_lock:
        global openice_proc_started
        if openice_proc_started:
            return
        openice_proc_started = True

    # print("openice_proc start")

    metric_id_dict = {
        "MDC_ECG_HEART_RATE":        "heart_rate",
        "MDC_TTHOR_RESP_RATE":       "respiration_rate",
        "MDC_PRESS_BLD_ART_ABP_DIA": "diastolic",
        "MDC_PRESS_BLD_ART_ABP_SYS": "systolic",
        "MDC_AWAY_CO2_ET":           "etCO2",
        "MDC_PULS_OXIM_SAT_O2":      "sp_o2",
    }

    flag = None
    proc = Popen("./run-hello-openice.sh", shell=True, bufsize=1, stdout=PIPE)

    print("openice_proc proc started")

    for line in proc.stdout:
        # TODO regex?
        line = ''.join(e for e in line.decode('ascii')
                       if (e.isalnum() or e in string.punctuation))
        line = line.split(":")

        if line[0] == "metric_id" and line[1] in metric_id_dict:
            flag = metric_id_dict[line[1]]
        elif line[0] == "value" and flag is not None:
            # TODO this conversion seems odd
            enqueue_to_sockets({flag: int(float(line[1]))})
            flag = None

    print("openice_proc end")


def dict_factory(cursor, row):
    """Convert database row objects to a dictionary."""
    output = {}
    for idx, col in enumerate(cursor.description):
        output[col[0]] = row[idx]
    return output


def get_db():
    """Open a new database connection."""
    if not hasattr(flask.g, 'sqlite_db'):
        flask.g.sqlite_db = sqlite3.connect(
            DATABASE_FILENAME)
        flask.g.sqlite_db.row_factory = dict_factory

        # Foreign keys have to be enabled per-connection.  This is an sqlite3
        # backwards compatibility thing.
        flask.g.sqlite_db.execute("PRAGMA foreign_keys = ON")

    return flask.g.sqlite_db


@app.teardown_appcontext
def close_db(error):
    # pylint: disable=unused-argument
    """Close the database at the end of a request."""
    if hasattr(flask.g, 'sqlite_db'):
        flask.g.sqlite_db.commit()
        # flask.g.sqlite_db.close()


# # Return True when the user types the correct username and password
# def _is_password_match(user_input_password, database_stored_password):
#     # Split the password stored in the database to three parts
#     password_anatomy = database_stored_password.split('$')
#     algorithm = password_anatomy[0]
#     salt = password_anatomy[1]
#     correct_password_salted_hash = password_anatomy[2]
#     # Check whether the passwords match
#     hash_obj = hashlib.new(algorithm)
#     user_input_password_salted = salt + user_input_password
#     hash_obj.update(user_input_password_salted.encode('utf-8'))
#     user_input_password_salted_hash = hash_obj.hexdigest()
#     return user_input_password_salted_hash == correct_password_salted_hash


@app.route("/", methods=['GET'])
def index():
    if 'logged_in_username' not in session:
        return redirect('/login')
    return render_template('index.html')


@app.route("/login", methods=['GET'])
def login_page():
    return render_template('login.html', wrongPassword=False)


@app.route("/login", methods=['POST'])
def login_form():
    db = get_db()
    cur = db.execute('SELECT * FROM users WHERE username=?',
                     (request.form['username'],))
    database_query_result = cur.fetchone()
    if database_query_result is not None:
        true_hash = database_query_result['password_hash']
        salt = database_query_result['password_salt']

        input_hash = scrypt.hash(request.form['password'].encode('utf-8'),
                                 salt)

        if true_hash == input_hash:
            session['logged_in_username'] = request.form['username']
            session['admin_logged_in'] = database_query_result['is_admin']
            return redirect('/')

    return render_template('login.html', wrongPassword=True)


@app.route("/logout", methods=['POST'])
def logout():
    if 'logged_in_username' in session:
        del session['logged_in_username']
    return redirect('/login')


@app.route("/create_account", methods=['GET'])
def create_account_page():
    return render_template("create_account.html")


@app.route("/create_account", methods=['POST'])
def create_account():
    db = get_db()
    cur = db.execute('SELECT * FROM users WHERE username=?',
                     (request.form['username'],))
    database_query_result = cur.fetchone()
    if database_query_result is not None:
        # TODO "username taken" error
        return redirect('/create_account')

    salt = os.urandom(16)
    password_hash = scrypt.hash(request.form['password'], salt)

    db.execute('INSERT INTO users (username, password_hash, password_salt) '
               'VALUES (?, ?, ?)',
               (request.form['username'], password_hash, salt))

    db.commit()

    # TODO "account successfully created"
    return redirect('/login')


@app.route("/admin/generate_token", methods=['POST'])
def generate_token():
    tok = ''.join(str(ord(os.urandom(1)) % 10) for _ in range(12))
    # TODO custom expire time?
    expires = datetime.now() + timedelta(minutes=5)

    db = get_db()
    db.execute('INSERT INTO tokens (token, time_expires) VALUES (?, ?)',
               (tok, expires))

    db.commit()

    return ('', 204)


@app.route("/admin/get_tokens", methods=['GET'])
def get_tokens():
    db = get_db()

    db.execute('DELETE FROM tokens WHERE time_expires < ?', (datetime.now(),))
    db.commit()

    cur = db.execute('SELECT * FROM tokens')

    token_list = sorted(
        ((row['token'], row['time_expires'], row['time_created'])
         for row in cur.fetchall()),
        key=lambda t: t[1]
    )

    r = json.dumps(token_list)
    return Response(response=r, status=200, mimetype="application/json")


@app.route("/admin", methods=['GET'])
def admin():
    if 'admin_logged_in' not in session:
        return redirect('/login')

    return render_template('admin.html')


@sockets.route('/data')
def data_socket(ws):
    q = Queue()
    with connections_lock:
        connections[ws] = q

    try:
        while not ws.closed:
            s = q.get()

            ws.send(s)

    finally:
        with connections_lock:
            del connections[ws]


Thread(target=openice_proc).start()

with app.app_context():
    db = get_db()
    db.cursor().execute('''
CREATE TABLE IF NOT EXISTS users (
    username TEXT NOT NULL PRIMARY KEY,
    password_hash BLOB NOT NULL,
    password_salt BLOB NOT NULL,
    is_admin INTEGER NOT NULL DEFAULT 0,
    time_created TIMESTAMP DEFAULT CURRENT_TIMESTAMP
)''')
#     db.cursor().execute('''
# CREATE TABLE IF NOT EXISTS admin_password (
#     password_hash BLOB NOT NULL,
#     password_salt BLOB NOT NULL,
#     time_created TIMESTAMP DEFAULT CURRENT_TIMESTAMP
# )''')
    db.cursor().execute('''
CREATE TABLE IF NOT EXISTS tokens (
    token TEXT NOT NULL,
    time_expires TIMESTAMP,
    time_created TIMESTAMP DEFAULT CURRENT_TIMESTAMP
)''')
    db.commit()


if __name__ == "__main__":
    app.run(debug=True)
