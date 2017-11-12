"""
Insta485 index (main) view.

URLs include:
/
"""
import os
import uuid
import shutil
import tempfile
import hashlib
import arrow
import webserver
from flask import render_template, session, request, redirect, url_for, abort, send_from_directory

# Return True when the user types the correct username and password
def _is_password_match(user_input_password, database_stored_password):
    # Split the password stored in the database to three parts
    password_anatomy = database_stored_password.split('$')
    algorithm = password_anatomy[0]
    salt = password_anatomy[1]
    correct_password_salted_hash = password_anatomy[2]
    # Check whether the passwords match
    hash_obj = hashlib.new(algorithm)
    user_input_password_salted = salt + user_input_password
    hash_obj.update(user_input_password_salted.encode('utf-8'))
    user_input_password_salted_hash = hash_obj.hexdigest()
    return user_input_password_salted_hash == correct_password_salted_hash

@webserver.app.route("/", methods=['GET'])
def page_index():
    if True:
        return redirect(url_for('login'))
    return render_template('index.html')

@webserver.app.route("/login", methods=['GET', 'POST'])
def login():
    if request.method == 'POST':
        database = webserver.model.get_db()
        cur = database.execute('select password from users where username=?',
                               (request.form['username'],))
        database_query_result = cur.fetchone()
        if database_query_result is None:
            abort(403)
        # Check the password
        db_stored_password = database_query_result.get('password')
        if db_stored_password and _is_password_match(request.form['password'], db_stored_password):
            session['logged_in_user'] = request.form['username']
            return redirect(url_for('index'))
        else:
            abort(403)
    return render_template('login.html')

@webserver.app.route("/index", methods=['GET', 'POST'])
def index():
    return render_template('index.html')