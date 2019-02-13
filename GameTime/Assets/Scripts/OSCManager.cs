using UnityEngine;
using System.Collections;

using System; 
using System.Collections.Generic; 
using OSCsharp.Data; 
using OSCsharp.Net; 
using OSCsharp.Utils; 

public class OSCManager { 

	public UDPReceiver udpReceiver;

	public GameObject myPlayer;
	PlayerController myPlayerController;

	public int Port { get; private set; }

	public event EventHandler<OSCEventArgs> OnData;

	public OSCManager() : this(3333)
	{}

	public OSCManager(int port)
	{
		Port = port;

		udpReceiver = new UDPReceiver(Port, false);
		udpReceiver.MessageReceived += handlerOscMessageReceived;
		udpReceiver.ErrorOccured += handlerOscErrorOccured;

		//myPlayer = GameObject.Find("Player");
		//myPlayerController = (PlayerController)myPlayer.GetComponent<PlayerController>();
	}

	public void Connect()
	{
		Debug.Log ("OSC Connected......");
		Debug.Log(Port);
		if (!udpReceiver.IsRunning) udpReceiver.Start();
	}

	public void Disconnect()
	{
		if (udpReceiver.IsRunning) udpReceiver.Stop();
	}

	private void parseOscMessage(OscMessage message)
	{
		Debug.Log ("parseOscMessage: " + message.Address);

		switch (message.Address)
		{
		case "/roll-a-ball":    
			if (message.Data.Count == 0) return;

			var command = message.Data[0].ToString();

			switch (command) 
			{
			case "jump":
				var jumpValue = (int)message.Data [1];
				//Debug.Log ("jump: " + jumpValue);
				callPlayerJump (jumpValue);
				break;
			case "set":
				if (message.Data.Count < 4) return;
				var id = (int)message.Data[1];
				var xPos = (float)message.Data[2];
				var yPos = (float)message.Data[3];
				break;
			case "fseq":
				if (message.Data.Count < 2) return;
				//if (OnData != null) OnData(this, new OSCEventArgs(message.Data));
				if (OnData != null) OnData(this, new OSCEventArgs(message.Data.ToString()));
				break;
			}
			break;
		}
	}

	private void handlerOscErrorOccured(object sender, ExceptionEventArgs exceptionEventArgs)
	{
		//Debug.Log("OSC Error: " + exceptionEventArgs.ToString());
	}

	private void handlerOscMessageReceived(object sender, OscMessageReceivedEventArgs oscMessageReceivedEventArgs)
	{
		//Debug.Log("OSCManager:messagereceived");

		parseOscMessage(oscMessageReceivedEventArgs.Message);
	}

	private void callPlayerJump(float val)
	{
		//myPlayerController.oscJumpFunction(val);
		myPlayerController.oscJump = val;
		Debug.Log ("calling PlayerJump: " + val);

	}
}