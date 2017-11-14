import os

APPLICATION_ROOT = '/'

# Secret key for encrypting cookies
SECRET_KEY = b'/\x94\xa6\x06\x12\xd7\xa3\x9b\xaf6\xf2\t\x98P\xa7h\x87\x87\xed<\n\x81AI'
SESSION_COOKIE_NAME = 'login'

DATABASE_FILENAME = os.path.join(
    os.path.dirname(os.path.dirname(os.path.realpath(__file__))),
    'var', 'doctorHUD.sqlite3'
)