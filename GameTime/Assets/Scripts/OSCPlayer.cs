using UnityEngine;
using System.Collections;

public class OSCPlayer : MonoBehaviour {

	// [OSC] instantiate OSCScript class (holds all OSC references/methods)
	public OSCScript myOSCScript;

	void Awake()
	{
	}

	// Use this for initialization
	void Start () {

		GameObject myWorld = GameObject.Find("World");
		myOSCScript = ((OSCMaster)myWorld.GetComponent<OSCMaster>()).myOSCScript;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log("test");
		// [OSC] generate OSC output message with player position data
		myOSCScript.sendOSCPlayerPosition(this.transform.localPosition.x, this.transform.localPosition.z);//, this.rigidbody2D.velocity.x, this.rigidbody2D.velocity.y);

	}
}
