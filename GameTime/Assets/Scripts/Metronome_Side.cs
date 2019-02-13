using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome_Side : MonoBehaviour
{
	public AudioClip tick;
	
	public OSCScript myOSCScript;
	
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<AudioSource>().playOnAwake = false;
		GetComponent<AudioSource>().clip = tick;
		
		GameObject myWorld = GameObject.Find("World");
		myOSCScript = ((OSCMaster)myWorld.GetComponent<OSCMaster>()).myOSCScript;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	
	void OnCollisionEnter(Collision col){
		//GetComponent<AudioSource>().Play();
		Debug.Log(col.gameObject.name);
		if(col.gameObject.name == "Instrument1"){
			myOSCScript.SendContact(1.0f);
			Debug.Log("test1");
		}
		if(col.gameObject.name == "Instrument2"){
			myOSCScript.SendContact(2.0f);
			Debug.Log("test2");
		}
		if(col.gameObject.name == "Instrument3"){
			myOSCScript.SendContact(3.0f);
			Debug.Log("test3");
		}
    }
}
