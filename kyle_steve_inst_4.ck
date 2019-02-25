//////// INST 1 = mandS ////////
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
	Mandolin mand => ADSR adsr => dac;
	
	int counter;
	//0.3 => mand.gain;
	//20 => mand.lfoSpeed;
	//0.5 => mand.lfoDepth;
	
	0.25 => mand.bodySize;
	0.5 => mand.pluckPos;
	0.5 => mand.stringDamping;
	0 => mand.stringDetune;
	0.8 => mand.pluck;
	
	////////ADSR ENVELOPE PARAMETERS////////
	
	100::ms => dur attack;
	100::ms => dur decay;
	0.65 => float sustain;
	100::ms => dur release;
	
	//adsr.set(attack, decay, sustain, release);
	
	////////OUR SCALE/////////
	
	//[52,59,68,62,78,72] @=> int myscale[];
	[60, 65, 63, 67, 72, 77] @=> int myscale[];
	1500::ms => dur noteLength;
	
	Math.random2(0,1) => int rando;
	Std.mtof(myscale[note+rando] - 24) => mand.freq;
	//0.5 => mand.noteOn;
	
	adsr.keyOn();
	
	
	//mand.noteOff();
	700::ms => now;
	//mand.noteOff();
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
			spork ~ inst(2);
		}
		else if (playtog == 12)
		{
			spork ~ inst(4);
		}
		
		1::ms => now;
	}
	
	
}

/*

////////CODE TO LOOP THRU THE SCALE FOR SAVEKEEPING////////

Std.mtof(myscale[counter]) => mand.freq;
0.5 => mand.noteOn;
adsr.keyOn();

100::ms => now;

adsr.keyOff();

//300::ms => now;

(counter + 1)%8 => counter; //umandg modulus to prevent index crashing, loop thru scale

*/