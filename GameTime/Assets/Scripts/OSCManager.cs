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
	public List<Instrument_Controller> controllers = new List<Instrument_Controller>();
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

		controllers.Add(GameObject.Find("Instrument Controller 1").GetComponent<Instrument_Controller>());
		controllers.Add(GameObject.Find("Instrument Controller 2").GetComponent<Instrument_Controller>());
		controllers.Add(GameObject.Find("Instrument Controller 3").GetComponent<Instrument_Controller>());
		controllers.Add(GameObject.Find("Instrument Controller 4").GetComponent<Instrument_Controller>());
		
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
		//Debug.Log(message);
		
		// /pi/key i i i s s s
		
		int playerid, asciikey;

		switch (message.Address)
		{
		case "/pi/key":    
			if (message.Data.Count == 0) return;

			int.TryParse(message.Data[0].ToString(), out asciikey);
			int.TryParse((message.Data[4].ToString())[9].ToString(), out playerid);
			Debug.Log(asciikey);
			
			//this is a testing line
			//int.TryParse(message.Data[1].ToString(), out playerid);
			
			
			controllers[playerid-5].OSCUpdate(asciikey);
			
			
			
			break;
		}
	}

	private void handlerOscErrorOccured(object sender, ExceptionEventArgs exceptionEventArgs)
	{
		//Debug.Log("OSC Error: " + exceptionEventArgs.ToString());
	}

	private void handlerOscMessageReceived(object sender, OscMessageReceivedEventArgs oscMessageReceivedEventArgs)
	{
		Debug.Log("OSCManager:messagereceived");

		parseOscMessage(oscMessageReceivedEventArgs.Message);
	}

	private void callPlayerJump(float val)
	{
		//myPlayerController.oscJumpFunction(val);
		myPlayerController.oscJump = val;
		Debug.Log ("calling PlayerJump: " + val);

	}
}