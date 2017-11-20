#!/bin/bash

git submodule update --init

cd webserver

rm -r venv 2> /dev/null
rm database.db 2> /dev/null

python3 -m venv venv
source venv/bin/activate
pip3 install flask flask-sockets gunicorn scrypt

python3 setup.py
