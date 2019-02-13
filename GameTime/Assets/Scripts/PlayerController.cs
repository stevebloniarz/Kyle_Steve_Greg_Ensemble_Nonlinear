using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{	
	public float speed;
	public GUIText countText;
	public GUIText winText;
	private int count;
	private int numberOfGameObjects;

	public int myVariable;

	public OSCMaster myOSCMaster;

	public OSCScript myOSCScript;

	public float oscJump;

	AudioSource audio;

	void Start()
	{
		count = 0;
		SetCountText();
		winText.text = "";
		numberOfGameObjects = GameObject.FindGameObjectsWithTag("PickUp").Length;

		GameObject myWorld = GameObject.Find("World");
		myOSCScript = ((OSCMaster)myWorld.GetComponent<OSCMaster>()).myOSCScript;
	}
	
	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		float jump = Input.GetAxis("Jump");
			
		Vector3 movement = new Vector3(moveHorizontal, jump*10.0f, moveVertical);

		GetComponent<Rigidbody>().AddForce (movement * speed * Time.deltaTime);

		// osc triggered jump
		if (oscJump > 0f) {

			print ("oscJump: " + oscJump);

			movement = new Vector3(moveHorizontal, oscJump, moveVertical);
			GetComponent<Rigidbody>().AddForce (movement * speed * Time.deltaTime);

			oscJump = 0f;
		}
	}

	public void oscJumpFunction(float val)
	{
		print ("calling oscJump...");			
	}
	
	void OnTriggerEnter(Collider other) 
	{		
		if(other.gameObject.tag == "PickUp")
		{			
			if( other.GetComponent<Renderer>().enabled == true )
			{
				// Get the audio clip
				//AudioClip clip = (other.GetComponent<AudioSource> ()).clip;

				// Here are some different ways to handle discrete audio event triggering...

				// play sound on object using PlayOneShot
				//other.GetComponent<AudioSource>().PlayOneShot(clip);

				// play sound at location
				//Vector3 pickupLocation = new Vector3(other.transform.position.x, other.transform.position.y, other.transform.position.z) ;
				//AudioSource.PlayClipAtPoint( clip, pickupLocation, 0.5f );

				// then hide pickup object...
				//other.GetComponent<Renderer>().enabled = false;

				// or destroy pickup object
				//other.gameObject.SetActive(false);

				// or, do all of this in the PlayAudioClip.cs script

				// increment count
				count = count + 1;
				SetCountText();

				// send osc message using the count
				myOSCScript.sendPickupCount(count);
			}
		}
	}
	
	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString();
		if(count >= numberOfGameObjects)
		{
			winText.text = "YOU WIN!";
		}
	}
}
