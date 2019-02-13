using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PlayAudioClip : MonoBehaviour {
		
	AudioSource audio;

	void Start() {
		audio = GetComponent<AudioSource>();
	}		

	void OnTriggerEnter(Collider other) {

		if (other.tag == "Player")
		{	
			// get position from transform
			Vector3 pickupLocation = new Vector3(transform.position.x, transform.position.y, transform.position.z) ;

			AudioSource.PlayClipAtPoint( audio.clip, pickupLocation, 0.5f );

			//audio.Play();

			gameObject.SetActive(false);
		}
	}
}
