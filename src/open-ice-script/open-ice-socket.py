import socket
import random
from os import urandom
import time
import platform

metric_ids = {"crap": "heart_rate"}

heart_rate = 60
systolic = 120
diastolic = 80
sp_o2 = 96

random.seed(urandom(64))


def broadcast_fake_input():
    connect = initialize_socket()
    while True:
        generate_fake_num()
        metric_str = "heart_rate:" + str(heart_rate) + ";systolic:" + str(systolic) + ";diastolic:" + str(diastolic) + ";sp_o2:" + str(sp_o2) + ";"
        print(len(metric_str))
        connect.send(metric_str.encode(encoding='ascii'))
        time.sleep(1)


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
    sock = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    host = socket.gethostname()
    port = 56754
    print("host: " + host + " port: " + str(port))
    sock.bind(("10.211.55.2", port))
    sock.listen(5)
    connect, address = sock.accept()
    return connect


def generate_fake_num():
    global heart_rate, systolic, diastolic, sp_o2
    heart_rate += random.randint(-2, 2)
    systolic += random.randint(-2, 2)
    diastolic += random.randint(-2, 2)
    sp_o2 += random.randint(-1,1 )

if __name__ == "__main__":
    broadcast_fake_input()
