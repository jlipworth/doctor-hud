import socket

metric_ids = {"crap": "heart_rate"}


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




if __name__ == "__main__":
    broadcast_input()
