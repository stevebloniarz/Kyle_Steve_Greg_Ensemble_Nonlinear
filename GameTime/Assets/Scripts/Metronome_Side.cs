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
		if(col.gameObject.name == "Instrument4"){
			myOSCScript.SendContact(4.0f);
			Debug.Log("test3");
		}
		if(col.gameObject.name == "Instrument5"){
			myOSCScript.SendContact(5.0f);
			Debug.Log("test3");
		}
		if(col.gameObject.name == "Instrument6"){
			myOSCScript.SendContact(6.0f);
			Debug.Log("test3");
		}
		if(col.gameObject.name == "Instrument7"){
			myOSCScript.SendContact(7.0f);
			Debug.Log("test3");
		}
		if(col.gameObject.name == "Instrument8"){
			myOSCScript.SendContact(8.0f);
			Debug.Log("test3");
		}
		if(col.gameObject.name == "Instrument9"){
			myOSCScript.SendContact(9.0f);
			Debug.Log("test3");
		}
		if(col.gameObject.name == "Instrument10"){
			myOSCScript.SendContact(10.0f);
			Debug.Log("test3");
		}
		if(col.gameObject.name == "Instrument11"){
			myOSCScript.SendContact(11.0f);
			Debug.Log("test3");
		}
		if(col.gameObject.name == "Instrument12"){
			myOSCScript.SendContact(12.0f);
			Debug.Log("test3");
		}
    }
}
