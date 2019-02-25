using UnityEngine;
using System.Collections;

public class OSCMaster : MonoBehaviour {

	// [OSC] instantiate OSCScript class (holds all OSC references/methods)
	public OSCScript myOSCScript;

	public OSCManager myOSCManager;

	void Awake()
	{
		// [OSC] create new OSC connection pointing to localhost/127.0.0.1:6666
		myOSCScript = new OSCScript("127.0.0.1", 6666);	

		myOSCManager = new OSCManager (7000);
		myOSCManager.Connect();
	}

	void Start () {

	}

	void Update () {
		//if (myOSCManager.udpReceiver.IsRunning ) {
		//	print("IS RUNNING......");
		//}
	}
}
