from time import sleep

from flask import Flask, render_template
from flask_sockets import Sockets


app = Flask(__name__)
sockets = Sockets(app)



@app.route("/", methods=['GET'])
def page_index():
    return render_template('index.html')


@sockets.route('/data')
def data_socket(ws):
    from random import random
    while not ws.closed:
        ws.send(str(random()))
        sleep(0.3)


#if __name__ == "__main__":
#    app.run(debug=True)
