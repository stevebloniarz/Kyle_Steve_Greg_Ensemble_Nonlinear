using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metronome : MonoBehaviour
{
	public Transform start;
	public Transform end;
	
	public float travel_time = 1;
	public float initial_time;
	public float current_time;
	private float temp_time;
	private float offset_factor;
	
    // Start is called before the first frame update
    void Start()
    {
		initial_time = Time.time;
		current_time = initial_time;
		temp_time = Time.time;
		offset_factor = 0.25f*travel_time;
    }

    // Update is called once per frame
    void Update()
    {
		current_time += Time.time - temp_time;
		temp_time = Time.time;
		float lerp_factor = Mathf.Min((current_time - initial_time)/travel_time, 1);
		
		//Debug.Log(current_time);
		transform.position = Vector3.Lerp (start.position, end.position, lerp_factor);
		
		if (lerp_factor == 1){
			initial_time = Time.time;
			current_time = initial_time;
			Transform temp = start;
			start = end;
			end = temp;
		}
		
    }
}