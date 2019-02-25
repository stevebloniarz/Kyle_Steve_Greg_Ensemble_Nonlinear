//////// INST 2 = Wurley ////////
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
	Wurley wurl => dac;
	
	
	int counter;
	0.5 => wurl.gain;
	0.80 => wurl.afterTouch;
	0.2 => wurl.controlOne;
	0.15 => wurl.controlTwo;
	//9=> wurl.lfoSpeed;
	//0.25=> wurl.lfoDepth;
	
	//2 => wurl.phonemeNum;
	//1.0 => wurl.voiceMix;
	//10 => wurl.vibratoFreq;
	
	////////ADSR ENVELOPE PARAMETERS////////
	
	//500::ms => dur attack;
	//200::ms => dur decay;
	//0.65 => float sustain;
	//2000::ms => dur release;
	
	//adsr.set(attack, decay, sustain, release);
	
	////////OUR SCALE/////////
	
	[55, 58, 60, 63, 65, 67] @=> int myscale[];
	5000::ms => dur noteLength;
	
	Math.random2(0,1) => int rando;
	Std.mtof(myscale[note+rando] +12) => wurl.freq;
	0.5 => wurl.noteOn;
	
	0 => int i;
	
/*
	while (i < 3)
	{
		Std.mtof(myscale[(note+i)%3]) => wurl.freq;
		10::ms => now;
		i + 1 => i;
	}
*/
	
	//adsr.keyOn();
	
	noteLength => now;
	
	//adsr.keyOff();
}

////////OUR FUNCTIONALITY////////

while(true){
	
	oin => now;
	
	while (oin.recv(msg))
	{
		msg.getFloat(0) => playtog;
		
		
		//depending on the value in the message recieved, play the note in the array
		if( playtog == 4 )
		{
			spork ~ inst(0);
		} 
		else if (playtog == 5)
		{
			spork ~ inst(1);
		}
		else if (playtog == 6)
		{
			spork ~ inst(2);
		}
		
		1::ms => now;
	}
	
	
}

/*

////////CODE TO LOOP THRU THE SCALE FOR SAVEKEEPING////////

Std.mtof(myscale[counter]) => wurl.freq;
0.5 => wurl.noteOn;
adsr.keyOn();

100::ms => now;

adsr.keyOff();

//300::ms => now;

(counter + 1)%8 => counter; //using modulus to prevent index crashing, loop thru scale

*/