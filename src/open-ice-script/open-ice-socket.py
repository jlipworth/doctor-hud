import socket

metric_ids = {}


def broadcast_input():
    sock = initialize_socket()
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
                    shove_into_socket(id_str, input())
                    break


def shove_into_socket(sock, id_str, value):
    connect, address = sock.accept()
    sock.send(str(id_str + " " + value))
   

def initialize_socket():
    sock = socket.socket(socket.AF_UNIX, socket.SOCK_STREAM)
    host = socket.gethostname()
    port = 56754
    sock.bind(host, port)
    sock.listen(5)
    return sock




if __name__ == "__main__":
    broadcast_input()
