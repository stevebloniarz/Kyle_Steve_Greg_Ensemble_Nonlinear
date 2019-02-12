
////////OSC CONFIG////////
OscIn oin;
// create our OSC message
OscMsg msg;
// use port 6449
12322 => oin.port;
// create an address in the receiver
oin.addAddress( "/1/push1, f" );

0 => float playtog;

////////INSTRUMENT PARAMETERS/////////
Rhodey rhode => ADSR adsr => dac;

int counter;
0.8 => rhode.gain;
//20 => rhode.lfoSpeed;
//0.5 => rhode.lfoDepth;

500::ms => dur attack;
200::ms => dur decay;
0.65 => float sustain;
2000::ms => dur release;

adsr.set(attack, decay, sustain, release);

////////OUR SCALE/////////

[60,61,62,63,64,65,66,67] @=> int myscale[];

////////OUR FUNCTIONALITY////////

while(true){
	
	oin => now;
	
	while (oin.recv(msg))
	{
		msg.getFloat(0) => playtog;
		
		
		//depending on the value in the message recieved, play the note in the array
		if( playtog == 1 )
		{
			Std.mtof(myscale[0]) => rhode.freq;
			0.5 => rhode.noteOn;
			
			adsr.keyOn();
			
			100::ms => now;
			
			adsr.keyOff();
			
		} 
		else if (playtog == 2)
		{
			Stf.mtof(myscale[1]) => rhode.freq;
			0.5 => rhode.noteOn;
			
			adsr.keyOn();
			
			100::ms => now;
			
			adsr.keyOff();
		}
		else if (playtog == 3)
		{
			Std.mtof(myscale[2]) => rhode.freq;
			0.5 => rhode.noteOn;
			
			adsr.keyOn();
			
			100::ms => now;
			
			adsr.keyOff();
		}
		else if (playtog == 4)
		{
		
			Std.mtof(myscale[3]) => rhode.freq;
			0.5 => rhode.noteOn;
			
			adsr.keyOn();
			
			100::ms => now;
			
			adsr.keyOff();
			
		}
		1::ms => now;
	}
	
	
}


/*

////////CODE TO LOOP THRU THE SCALE FOR SAVEKEEPING////////

Std.mtof(myscale[counter]) => rhode.freq;
0.5 => rhode.noteOn;
adsr.keyOn();

100::ms => now;

adsr.keyOff();

//300::ms => now;

(counter + 1)%8 => counter; //using modulus to prevent index crashing, loop thru scale	
*/