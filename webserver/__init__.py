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
from geventwebsocket.exceptions import WebSocketError


DATABASE_FILENAME = os.path.join(
    os.path.dirname(os.path.realpath(__file__)),
    'database.db'
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
        # flask.g.sqlite_db.commit()
        flask.g.sqlite_db.close()


@app.route("/", methods=['GET'])
def index():
    if 'logged_in_username' not in session:
        return redirect('/login')

    now = datetime.utcnow()
    db = get_db()
    cur = db.execute('SELECT * FROM user_access WHERE username=?',
                     (session['logged_in_username'],))
    row = cur.fetchone()
    if row is None or \
       datetime.strptime(row['access_begins'], "%Y-%m-%d %H:%M:%S") > now or \
       datetime.strptime(row['access_ends'], "%Y-%m-%d %H:%M:%S") < now:
        session.clear()
        return render_template(
            'login.html',
            error_message="Login successful, but you have not been granted access at this time."
        )

    cur = db.execute('SELECT * FROM skype_account')
    skype_account = cur.fetchone()['account_name']

    if session.get("admin_logged_in", False):
        return render_template('index.html',
                               admin=True, skype_account=skype_account)

    return render_template('index.html',
                           admin=False, skype_account=skype_account)

@app.route("/login", methods=['GET'])
def login_page():
    return render_template('login.html', error_message="")


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

    return render_template(
        'login.html',
        error_message="Password or username is not correct."
    )


@app.route("/login_token", methods=['POST'])
def login_token():
    db = get_db()

    db.execute('DELETE FROM tokens WHERE time_expires < ?',
               (datetime.utcnow(),))
    db.commit()

    cur = db.execute('SELECT * FROM tokens WHERE token = ?',
                     (request.form['token'],))

    if cur.fetchone() is not None:
        db.execute('DELETE FROM tokens WHERE token = ?',
                   (request.form['token'],))
        db.commit()

        session['logged_in_username'] = "Guest"
        session['admin_logged_in'] = False
        return redirect('/')

    return render_template(
        'login.html',
        error_message="Token is invalid."
    )


# TODO probably don't support get here
@app.route("/logout", methods=['GET', 'POST'])
def logout():
    session.clear()
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

    salt = os.urandom(64)
    password_hash = scrypt.hash(request.form['password'], salt)

    db.execute('INSERT INTO users (username, password_hash, password_salt, is_admin)'
               'VALUES (?, ?, ?, ?)',
               (request.form['username'], password_hash, salt, 0))

    db.commit()

    # TODO "account successfully created"
    return redirect('/')


@app.route("/admin", methods=['GET'])
def admin():
    if not session.get("admin_logged_in", False):
        return redirect('/')

    db = get_db()
    cur = db.execute('SELECT username FROM users WHERE is_admin = 0')
    usernames = [u["username"] for u in cur.fetchall() if u["username"] != "Guest"]

    return render_template('admin.html', usernames=usernames)


@app.route("/admin/generate_token", methods=['POST'])
def generate_token():
    tok = ''.join(str(ord(os.urandom(1)) % 10) for _ in range(12))
    # TODO custom expire time?
    expires = datetime.utcnow() + timedelta(minutes=5)

    db = get_db()
    db.execute('INSERT INTO tokens (token, time_expires) VALUES (?, ?)',
               (tok, expires.replace(microsecond=0)))

    db.commit()

    return ('', 204)


@app.route("/admin/get_tokens", methods=['GET'])
def get_tokens():
    db = get_db()

    db.execute('DELETE FROM tokens WHERE time_expires < ?',
               (datetime.utcnow(),))
    db.commit()

    cur = db.execute('SELECT * FROM tokens')

    token_list = sorted(
        ((row['token'], row['time_expires'], row['time_created'])
         for row in cur.fetchall()),
        key=lambda t: t[1]
    )

    r = json.dumps(token_list)
    return Response(response=r, status=200, mimetype="application/json")


@app.route("/admin/give_access", methods=['POST'])
def give_access():
    if request.form['username']:
        db = get_db()
        db.execute('INSERT INTO user_access (username, access_begins, access_ends)'
                   ' VALUES (?, ?, ?)',
                   (
                       request.form['username'],
                       datetime.strptime(request.form['access_begins'],
                                         "%Y-%m-%dT%H:%M"),
                       datetime.strptime(request.form['access_ends'],
                                         "%Y-%m-%dT%H:%M"),
                   ))

        db.commit()

    return ('', 204)


@app.route("/admin/get_accesses", methods=['GET'])
def get_accesses():
    db = get_db()

    db.execute('DELETE FROM user_access WHERE access_ends < ?',
               (datetime.utcnow(),))
    db.commit()

    cur = db.execute('SELECT * FROM user_access')

    access_list = sorted(
        ((row['username'], row['access_begins'], row['access_ends'])
         for row in cur.fetchall()),
        key=lambda t: t[1]
    )

    r = json.dumps(access_list)
    return Response(response=r, status=200, mimetype="application/json")


@sockets.route('/data')
def data_socket(ws):
    q = Queue()
    with connections_lock:
        connections[ws] = q

    try:
        while not ws.closed:
            s = q.get()
            ws.send(s)

    except WebSocketError as e:
        print("websocket error:", e)

    finally:
        with connections_lock:
            del connections[ws]


Thread(target=openice_proc).start()


if __name__ == "__main__":
    app.run(debug=True)
