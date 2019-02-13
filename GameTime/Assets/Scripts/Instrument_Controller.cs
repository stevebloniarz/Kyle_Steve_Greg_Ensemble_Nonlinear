using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrument_Controller : MonoBehaviour
{
	public List<GameObject> instruments = new List<GameObject>();
	private Metronome current_instrument;
	private float travel_time = 1f;
	private float offset_factor = 0.125f;
	private int index = 0;
	
    // Start is called before the first frame update
    void Start()
    {
        current_instrument = instruments[index].GetComponent<Metronome>();
    }

    // Update is called once per frame
    void Update()
    {
		
		float lerp_factor = current_instrument.current_time - current_instrument.initial_time;
		
		//speed
        if (Input.GetKeyDown("w")){
			current_instrument.travel_time += 0.05f;
		}
		if (Input.GetKeyDown("s")){
			current_instrument.travel_time -= 0.05f;
			if (current_instrument.travel_time <= 0.1f){
				current_instrument.travel_time = 0.1f;
			}
		}
		
		//offset
		if (Input.GetKeyDown("d")){
			if (lerp_factor < current_instrument.travel_time-offset_factor){
				current_instrument.current_time += offset_factor;
			}
		}
		if (Input.GetKeyDown("a")){
			if (lerp_factor > offset_factor){
				current_instrument.current_time -= offset_factor;
			}
		}
		
		//choose instrument
		if (Input.GetKeyDown("up")){
			if (index == 2){
				index = 0;
			} else {
				index += 1;
			}
			current_instrument = instruments[index].GetComponent<Metronome>();
		}
		if (Input.GetKeyDown("down")){
			if (index == 0){
				index = 2;
			} else {
				index -= 1;
			}
			current_instrument = instruments[index].GetComponent<Metronome>();
		}
    }
}
