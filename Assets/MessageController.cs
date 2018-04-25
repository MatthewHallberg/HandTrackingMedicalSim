using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System.Net;
using System.Text;

public class MessageController : MonoBehaviour {

	public HandRepresentation hand;

	private const int PORT_NUM = 1999;
	private const float UPDATE_TIME = .5f;

	private string serverIP = "10.215.39.212";
	private IPAddress serverAddr;
	private IPEndPoint endPoint;
	private Socket sock;
	private byte[] send_buffer;
	private bool sendingMessages = false;

	public void SetIP(string IP){
		serverIP = IP;
		Debug.Log ("New Server IP: " + IP);
	}

	public void ToggleSendMessages(){
		if (sendingMessages) {
			sendingMessages = false;
			StopSendMessages ();
		} else {
			sendingMessages = true;
			StartSendingMessages ();
		}
	}

	void StartSendingMessages(){
		Debug.Log ("Starting Messages...");
		//init socket
		sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram,ProtocolType.Udp);
		serverAddr = IPAddress.Parse(serverIP);
		endPoint = new IPEndPoint(serverAddr, PORT_NUM);
		//start looping coroutine
		SendPosCoroutine = StartCoroutine (SendPosition ());
	}

	void StopSendMessages(){
		if (SendPosCoroutine != null) {
			Debug.Log ("Stopping Messages...");
			StopCoroutine (SendPosCoroutine);
			sock.Disconnect (true);
		}
	}

	Coroutine SendPosCoroutine;
	IEnumerator SendPosition(){
		while (true) {
			string text = hand.GetPosition ().ToString ();
			send_buffer = Encoding.ASCII.GetBytes(text);
			sock.SendTo(send_buffer,endPoint);
			print (text);
			yield return new WaitForSeconds (UPDATE_TIME);
		}
	}
}
