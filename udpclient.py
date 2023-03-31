import socket
import json
import time
import random

# UDP_IP = "192.168.0.15"
UDP_IP = "127.0.0.1"
UDP_PORT = 5000

print("UDP target IP: %s" % UDP_IP)
print("UDP target port: %s" % UDP_PORT)

sock = socket.socket(socket.AF_INET,  # Internet
                     socket.SOCK_DGRAM)  # UDP
while True:
    # JSON verisini oluştur
    json_data = {
        "red":  random.randint(0, 180),
        "blue":  random.randint(0, 180),
        "green":  random.randint(0, 180),
        "distance":  random.randint(0, 40)
    }
    message = json.dumps(json_data).encode()
    client_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    client_socket.sendto(message, (UDP_IP, UDP_PORT))

    client_socket.close()
    time.sleep(0.275)
