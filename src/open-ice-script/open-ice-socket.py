import socket

metric_ids = {}


def broadcast_input():
    while True:
        input_word = input()
        if input_word == "metric_id:" and dict.get(input_word, None) is not None:
            # this will be the id associated with it
            id = input()
            while True:
                input_word = input()
                # if we need more could insert this into dict
                # seems that every piece of info has this field
                if input_word == "value:":
                    shove_into_socket(id, input())
                    break


def shove_into_socket(id, value):
    


if __name__ == "__main__":
    broadcast_input()
