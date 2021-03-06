//////// INST 1 = RHODES ////////
////////OSC CONFIG////////
OscIn oin;
// create our OSC message
OscMsg msg;
// use port 6449
6449 => oin.port;
// create an address in the receiver
oin.addAddress( "/playerNumber, f" );

0 => float playtog;


fun void inst(int note){
	////////INSTRUMENT PARAMETERS/////////
	Rhodey rhode => ADSR adsr => dac;
	
	int counter;
	0.8 => rhode.gain;
	//20 => rhode.lfoSpeed;
	//0.5 => rhode.lfoDepth;
	
	////////ADSR ENVELOPE PARAMETERS////////
	
	500::ms => dur attack;
	200::ms => dur decay;
	0.65 => float sustain;
	2000::ms => dur release;
	
	adsr.set(attack, decay, sustain, release);
	
	////////OUR SCALE/////////
	
	[60,64,67] @=> int myscale[];
	
	1500::ms => dur noteLength;
	
	Std.mtof(myscale[note]) => rhode.freq;
	0.5 => rhode.noteOn;
	
	adsr.keyOn();
	
	noteLength => now;
	
	adsr.keyOff();
}

////////OUR FUNCTIONALITY////////

while(true){
	
	oin => now;
	
	while (oin.recv(msg))
	{
		msg.getFloat(0) => playtog;
		
		
		//depending on the value in the message recieved, play the note in the array
		if( playtog == 1 )
		{
			spork ~ inst(0);
		} 
		else if (playtog == 2)
		{
			spork ~ inst(1);
		}
		else if (playtog == 3)
		{
			spork ~ inst(2);
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