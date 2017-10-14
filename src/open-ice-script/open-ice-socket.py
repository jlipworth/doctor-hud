import socket
import random
from os import urandom

metric_ids = {"crap": "heart_rate"}

heart_rate = 60
systolic = 120
diastolic = 80
sp_o2 = 98

rng = random.seed(urandom(64))


def broadcast_fake_input():
    connect = initialize_socket()
    while True:
        generate_fake_num()
        connect.send("1: " + heart_rate + " 2: " + systolic + " 3: "
                     + diastolic + " 4: " + sp_o2)



def broadcast_input():
    connect = initialize_socket()
    while True:
        input_word = input()
        if input_word == "metric_id:" and dict.get(input_word, None) is not None:
            # this will be the id associated with it
            id_str = input()
            while True:
                input_word = input()
                # if we need more could insert this into dict
                # seems that every piece of info has this field
                if input_word == "value:":
                    connect.send(id_str + " " + input())
                    break


def initialize_socket():
    sock = socket.socket()
    host = socket.gethostname()
    port = 56754
    print("host: " + host + " port: " + str(port))
    sock.bind((host, port))
    sock.listen(5)
    connect, address = sock.accept()
    return connect


def generate_fake_num():
    global heart_rate, systolic, diastolic, sp_o2
    heart_rate += rng.randint(-2, 2)
    systolic += rng.randint(-2, 2)
    diastolic += rng.randint(-2, 2)


if __name__ == "__main__":
    broadcast_fake_input()
