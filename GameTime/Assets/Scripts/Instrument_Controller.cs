using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instrument_Controller : MonoBehaviour
{
	public List<GameObject> instruments = new List<GameObject>();
	public Material temp_material;
	public Material chosen;
	public Metronome current_instrument;
	//private float travel_time = 1f;
	private float offset_factor = 0.125f;
	public int index = 0;
	private int input_variable = -1;
	public List<GameObject> indicator_locations = new List<GameObject>();
	public GameObject indicator;
	
	
    // Start is called before the first frame update
    void Start()
    {
        current_instrument = instruments[index].GetComponent<Metronome>();
		temp_material = instruments[index].GetComponent<Renderer>().material;
		//instruments[index].GetComponent<Renderer>().material = chosen;
		indicator.transform.position = indicator_locations[index].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
		
		float lerp_factor = current_instrument.current_time - current_instrument.initial_time;
		
		//speed
        //if (Input.GetKeyDown("w")){
		if (input_variable == 17){
			current_instrument.travel_time += 0.05f;
		}
		//if (Input.GetKeyDown("s")){
		if (input_variable == 31){
			current_instrument.travel_time -= 0.05f;
			if (current_instrument.travel_time <= 0.1f){
				current_instrument.travel_time = 0.1f;
			}
		}
		
		//offset
		//if (Input.GetKeyDown("d")){
		if (input_variable == 32){
			if (lerp_factor < current_instrument.travel_time-offset_factor){
				current_instrument.current_time += offset_factor;
			}
		}
		//if (Input.GetKeyDown("a")){
		if (input_variable == 30){
			if (lerp_factor > offset_factor){
				current_instrument.current_time -= offset_factor;
			}
		}
		
		//choose instrument
		//if (Input.GetKeyDown("up")){
		if (input_variable == 103){
			instruments[index].GetComponent<Renderer>().material = temp_material;
			if (index == 2){
				index = 0;
			} else {
				index += 1;
			}
			
			
			/*
			Renderer temp_render = instruments[index].GetComponent<Renderer>();
			temp_material = temp_render.material;
			temp_render.material = chosen;
			*/
			
			current_instrument = instruments[index].GetComponent<Metronome>();
			indicator.transform.position = indicator_locations[index].transform.position;
		}
		
		//if (Input.GetKeyDown("down")){
		if (input_variable == 108){
			instruments[index].GetComponent<Renderer>().material = temp_material;
			if (index == 0){
				index = 2;
			} else {
				index -= 1;
			}
			/*
			Renderer temp_render = instruments[index].GetComponent<Renderer>();
			temp_material = temp_render.material;
			temp_render.material = chosen;
			*/
			
			current_instrument = instruments[index].GetComponent<Metronome>();
			indicator.transform.position = indicator_locations[index].transform.position;
		}
		
		//if (Input.GetKeyDown("g")){
		if (input_variable == 34){
			//instruments[index].SetActive(!instruments[index].activeInHierarchy);
			if (instruments[index].transform.localScale.x == 0){
				instruments[index].transform.localScale =  new Vector3(1,1,1);
			} else {
				instruments[index].transform.localScale = new Vector3(0,0,0);
			}
		}
		
		//if (Input.GetKeyDown("r")){
		if (input_variable == 19){
			foreach (GameObject i in instruments){
				Metronome temp = i.GetComponent<Metronome>();
				temp.current_time = temp.initial_time+0.5f*temp.travel_time;
			}
		}
		
		//if (Input.GetKeyDown("j")){
		if (input_variable == 36){
			foreach (GameObject i in instruments){
				Metronome temp = i.GetComponent<Metronome>();
				temp.moving = !temp.moving;
			}
		}
		
		//if (Input.GetKeyDown("h")){
		if (input_variable == 35){
			foreach (GameObject i in instruments){
				Metronome temp = i.GetComponent<Metronome>();
				temp.travel_time = 1;
			}
		}
		
		//if (Input.GetKeyDown("o")){
		if (input_variable == 24){
			foreach (GameObject i in instruments){
				Metronome temp = i.GetComponent<Metronome>();
				temp.travel_time = 1;
				temp.current_time = temp.initial_time+0.5f*temp.travel_time;
			}
		}
		
		input_variable = -1;
    }
	
	public void OSCUpdate(int asciikey){
		Debug.Log(asciikey);
		input_variable = asciikey;	
	}
}
