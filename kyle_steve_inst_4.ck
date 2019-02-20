//////// INST 1 = sinS ////////
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
	SinOsc sin => ADSR adsr => dac;
	
	int counter;
	0.3 => sin.gain;
	//20 => sin.lfoSpeed;
	//0.5 => sin.lfoDepth;
	
	////////ADSR ENVELOPE PARAMETERS////////
	
	500::ms => dur attack;
	200::ms => dur decay;
	0.65 => float sustain;
	1000::ms => dur release;
	
	adsr.set(attack, decay, sustain, release);
	
	////////OUR SCALE/////////
	
	[52,59,68,62,78,72] @=> int myscale[];
	
	1500::ms => dur noteLength;
	
	Std.mtof(myscale[note] - 24) => sin.freq;
	//0.5 => sin.noteOn;
	
	adsr.keyOn();
	
	
	//sin.noteOff();
	700::ms => now;
	//sin.noteOff();
	adsr.keyOff();
	1000::ms => now;
}

////////OUR FUNCTIONALITY////////

while(true){
	
	oin => now;
	
	while (oin.recv(msg))
	{
		msg.getFloat(0) => playtog;
		
		
		//depending on the value in the message recieved, play the note in the array
		if( playtog == 10 )
		{
			spork ~ inst(0);
		} 
		else if (playtog == 11)
		{
			spork ~ inst(1);
		}
		else if (playtog == 12)
		{
			spork ~ inst(2);
		}
		
		1::ms => now;
	}
	
	
}

/*

////////CODE TO LOOP THRU THE SCALE FOR SAVEKEEPING////////

Std.mtof(myscale[counter]) => sin.freq;
0.5 => sin.noteOn;
adsr.keyOn();

100::ms => now;

adsr.keyOff();

//300::ms => now;

(counter + 1)%8 => counter; //using modulus to prevent index crashing, loop thru scale

*/