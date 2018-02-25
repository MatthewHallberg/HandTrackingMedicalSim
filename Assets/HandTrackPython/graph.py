from mpl_toolkits.mplot3d import Axes3D
import matplotlib.pyplot as plt
import numpy as np
import random
import threading

def start_listening():
	import GetHandPos

a = threading.Thread(target=start_listening)
a.start()

plt.ion()
fig = plt.figure()
ax = fig.add_subplot(111, projection='3d')
x, y, z = [],[],[]
ax.scatter(x,y,z)
plt.plot(x,y,z)
plt.draw()
print("GRAPHING")

for i in range(1000):
    ax.clear()
    #ax.scatter(FakeHandPos.xValues,FakeHandPos.yValues,FakeHandPos.zValues)
    #plt.plot(FakeHandPos.xValues,FakeHandPos.yValues,FakeHandPos.zValues)
    ax.scatter(GetHandPos.xValues,GetHandPos.yValues,GetHandPos.zValues)
    plt.plot(GetHandPos.xValues,GetHandPos.yValues,GetHandPos.zValues)
    plt.draw()
    plt.pause(.5)

plt.waitforbuttonpress()