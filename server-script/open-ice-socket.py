import socket
import random
from os import urandom
import time
import platform
import sys
import string

metric_ids = {"crap": "heart_rate"}

data = {"heart_rate":0, "respiration_rate":0, "systolic":0, "diastolic":0, "sp_o2":0, "etCO2":0}

metric_id_dict = {"MDC_ECG_HEART_RATE": "heart_rate",
"MDC_TTHOR_RESP_RATE": "respiration_rate",
"MDC_PRESS_BLD_ART_ABP_DIA": "diastolic",
"MDC_PRESS_BLD_ART_ABP_SYS": "systolic",
"MDC_AWAY_CO2_ET": "etCO2",
"MDC_PULS_OXIM_SAT_O2": "sp_o2"
}

# Fake data
heart_rate = 60
systolic = 120
diastolic = 80
sp_o2 = 96
etCO2 = 0
respiration_rate = 0
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
    flag = None
    while True:
        cnt = 0
        while cnt < 6:
            line = sys.stdin.readline()
            assert isinstance(line, str)
            # Replace these lines with a regex later
            line = ''.join(e for e in line if (e.isalnum() or e in string.punctuation))
            line = line.split(":")
            # print(line)
            if line[0] == "metric_id" and line[1] in metric_id_dict:
                flag = metric_id_dict[line[1]]
            elif line[0] == "value" and flag != None:
                data[flag] = int(float(line[1]))
                print(flag, data[flag])
                flag = None
                cnt += 1

        metric_str = "heart_rate:" + str(data["heart_rate"]) + ";systolic:" + str(data["systolic"]) + ";diastolic:" + str(data["diastolic"]) + ";sp_o2:" + str(data["sp_o2"]) + ";respiration_rate:" + str(data["respiration_rate"]) + ";etCO2:" + str(data["etCO2"]) + ";"
        print("metric_str:" , metric_str)
        connect.send(metric_str.encode(encoding='ascii'))

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
    if sys.argc > 1:
        broadcast_fake_input()
    else:
        broadcast_input()
