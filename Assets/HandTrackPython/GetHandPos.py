#matthew hallberg
import socket
SENDING_IP = "192.168.1.151"
UDP_PORT = 1999
sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM) # UDP
sock.bind((SENDING_IP, UDP_PORT))
print ("start listening...")

while True:
	data, addr = sock.recvfrom(28) # buffer size is 1024 bytes
	print (data)
