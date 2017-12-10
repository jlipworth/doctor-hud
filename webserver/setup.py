
import os
from getpass import getpass
from datetime import datetime

import sqlite3
import scrypt


admin_username = input("Admin account username: ")
admin_password = getpass("Admin account password: ")
skype_account = input("Skype account username: ")

db = sqlite3.connect('database.db')

db.execute('''
CREATE TABLE users (
    username TEXT NOT NULL PRIMARY KEY,
    password_hash BLOB NOT NULL,
    password_salt BLOB NOT NULL,
    is_admin INTEGER NOT NULL DEFAULT 0,
    time_created TIMESTAMP DEFAULT CURRENT_TIMESTAMP
)''')

db.execute('''
CREATE TABLE user_access (
    username TEXT NOT NULL,
    access_begins TIMESTAMP NOT NULL,
    access_ends TIMESTAMP NOT NULL
)''')

db.execute('''
CREATE TABLE saved_notes (
    username TEXT NOT NULL PRIMARY KEY,
    note TEXT NOT NULL
)''')

db.execute('''
CREATE TABLE tokens (
    token TEXT NOT NULL PRIMARY KEY,
    time_expires TIMESTAMP NOT NULL,
    time_created TIMESTAMP DEFAULT CURRENT_TIMESTAMP
)''')

db.execute('''
CREATE TABLE skype_account (
    account_name TEXT NOT NULL PRIMARY KEY
)''')

admin_salt = os.urandom(64)
db.execute('''
INSERT INTO users (username, password_hash, password_salt, is_admin)
    VALUES (?, ?, ?, ?)''',
           (admin_username, scrypt.hash(admin_password, admin_salt), admin_salt, 1))

# "Guest" account for token login, can't actually log in directly
db.execute('''
INSERT INTO users (username, password_hash, password_salt, is_admin)
    VALUES (?, ?, ?, ?)''',
           ("Guest", os.urandom(128), b"\0", 0))

db.execute('''
INSERT INTO user_access (username, access_begins, access_ends)
    VALUES (?, ?, ?)''',
           (admin_username, datetime.min, datetime.max.replace(microsecond=0)))

db.execute('''
INSERT INTO user_access (username, access_begins, access_ends)
    VALUES (?, ?, ?)''',
           ("Guest", datetime.min, datetime.max.replace(microsecond=0)))

db.execute('INSERT INTO saved_notes (username, note) VALUES (?, ?)',
           (admin_username, ""))

db.execute('INSERT INTO saved_notes (username, note) VALUES (?, ?)',
           ("Guest", ""))

db.execute('''INSERT INTO skype_account (account_name) VALUES (?)''',
           (skype_account,))

db.commit()
