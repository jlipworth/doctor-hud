#!/bin/sh

# http
gunicorn -k flask_sockets.worker -b 'localhost:8080' __init__:app

# https
# gunicorn -k flask_sockets.worker --ssl-version=5 --ciphers="ECDHE-ECDSA-AES256-GCM-SHA384:ECDHE-RSA-AES256-GCM-SHA384:ECDHE-ECDSA-CHACHA20-POLY1305:ECDHE-RSA-CHACHA20-POLY1305:ECDHE-ECDSA-AES128-GCM-SHA256:ECDHE-RSA-AES128-GCM-SHA256:ECDHE-ECDSA-AES256-SHA384:ECDHE-RSA-AES256-SHA384:ECDHE-ECDSA-AES128-SHA256:ECDHE-RSA-AES128-SHA256" --certfile=../fullchain.pem --keyfile=../privkey.pem -b '0.0.0.0:8443' __init__:app

#wait
#trap 'kill -HUP 0' EXIT
