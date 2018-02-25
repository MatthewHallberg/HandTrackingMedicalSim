#matthew hallberg
import socket
from mpl_toolkits.mplot3d import Axes3D
import matplotlib.pyplot as plt
import numpy as np
import random
import threading

global xValues
global yValues
global zValues
xValues,yValues,zValues = [],[],[]

def listen():
	SENDING_IP = "192.168.1.151"
	UDP_PORT = 1999
	sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM) # UDP
	sock.bind((SENDING_IP, UDP_PORT))
	print ("start listening...")

	def ParseMessage(message):
		#remove leading and trailing characters from string
		message = message[3:]
		message = message[:-2]
		message = message.strip()
		message = message.split(',')
		GraphCoordinates(message)

	def GraphCoordinates(message):
		if (len(message) > 0):
			x = float(message[0])
			if isinstance(x, float):
				xValues.append(x)
		if (len(message) > 1):
			y = float(message[1])
			if isinstance(y, float):
				yValues.append(y)
		if (len(message) > 2):
			z = float(message[2])
			if isinstance(z, float):
				zValues.append(z)
		print(x)

	while True:
		data, addr = sock.recvfrom(28) # buffer size is 1024 bytes
		message = str(data)
		ParseMessage(message)

a = threading.Thread(target=listen)
a.start()

plt.ion()
fig = plt.figure()
ax = fig.add_subplot(111, projection='3d')
print("GRAPHING")
for i in range(10000):
	ax.clear()
	ax.scatter(xValues,yValues,zValues)
	plt.plot(xValues,yValues,zValues)
	plt.draw()
	plt.pause(.1)

plt.waitforbuttonpress()

