// ------------------------------------------------------------------------------
//      OSCsharp class
//      by Rob Hamilton
//      Mono Runtime Version: 4.0.30319.1
// ------------------------------------------------------------------------------
using System;

using OSCsharp.Net;
using OSCsharp.Data;

public class OSCScript
{
	public UDPTransmitter oscTransmitter;
	public OscPacket testOscPacket;
	public OscMessage controllerOscMessage;

	private String sphereNamespace = "/sphere";
	private String spherePositionNamespace = "/sphere/position";
	private String spherePickupNamespace = "/sphere/pickup"; 

	public OSCScript ()
	{	
		oscTransmitter = setOSCTarget ("192.168.0.111", 6666);
		oscTransmitter.Connect ();
	}

	public OSCScript (string ip, int port)
	{
		oscTransmitter = setOSCTarget (ip, port);
		oscTransmitter.Connect ();
	}
		
	UDPTransmitter setOSCTarget(string ip, int port)
	{
		return new UDPTransmitter (ip, port);
	}

	UDPReceiver setOSCReceive(int port)
	{
		return new UDPReceiver (port, true);
	}

	// --- game functions ---
	public void sendOSCPlayerPosition(float x, float z)
	{
		//controllerOscMessage = new OscMessage (spherePositionNamespace);
		controllerOscMessage = new OscMessage ("/playerPositionX");
		//print("Test");
		controllerOscMessage.Append (x);
		//controllerOscMessage.Append (z);
		//controllerOscMessage.Append("/1/toggle1, f");
			
		//oscTransmitter.Send (controllerOscMessage);

		// /sphere/position 8.3 -3.1
	}

	public void sendPickupCount(int count)
	{
		controllerOscMessage = new OscMessage ("/playerPositionX");
		controllerOscMessage.Append (1.0f);

		oscTransmitter.Send (controllerOscMessage);
	}
	public void SendContact(float block_number)
	{
		controllerOscMessage = new OscMessage ("/playerNumber");
		controllerOscMessage.Append(block_number);
		oscTransmitter.Send(controllerOscMessage);
	}
}


