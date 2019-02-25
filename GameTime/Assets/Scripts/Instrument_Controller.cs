using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrument_Controller : MonoBehaviour
{
	public List<GameObject> instruments = new List<GameObject>();
	public Material temp_material;
	public Material chosen;
	private Metronome current_instrument;
	private float travel_time = 1f;
	private float offset_factor = 0.125f;
	private int index = 0;
	
    // Start is called before the first frame update
    void Start()
    {
        current_instrument = instruments[index].GetComponent<Metronome>();
		temp_material = instruments[index].GetComponent<Renderer>().material;
		instruments[index].GetComponent<Renderer>().material = chosen;
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
			instruments[index].GetComponent<Renderer>().material = temp_material;
			if (index == 11){
				index = 0;
			} else {
				index += 1;
			}
			Renderer temp_render = instruments[index].GetComponent<Renderer>();
			temp_material = temp_render.material;
			temp_render.material = chosen;
			
			current_instrument = instruments[index].GetComponent<Metronome>();
		}
		if (Input.GetKeyDown("down")){
			instruments[index].GetComponent<Renderer>().material = temp_material;
			if (index == 0){
				index = 11;
			} else {
				index -= 1;
			}
			Renderer temp_render = instruments[index].GetComponent<Renderer>();
			temp_material = temp_render.material;
			temp_render.material = chosen;
			current_instrument = instruments[index].GetComponent<Metronome>();
		}
		
		if (Input.GetKeyDown("g")){
			instruments[index].SetActive(!instruments[index].activeInHierarchy);
		}
		
		if (Input.GetKeyDown("r")){
			foreach (GameObject i in instruments){
				Metronome temp = i.GetComponent<Metronome>();
				//do math
				//temp.travel_time = current_instrument.travel_time
			}
		}
    }
}
