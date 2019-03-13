//////// INST 3 = DRUMS ////////
////////OSC CONFIG////////
OscIn oin;
// create our OSC message
OscMsg msg;
// use port 6449
6666 => oin.port;
// create an address in the receiver
oin.addAddress( "/playerNumber, f" );

0 => float playtog;

//our drum samples
SndBuf buf1;
SndBuf buf2;
SndBuf buf3;
buf1 => dac;
buf2 => dac;
buf3 => dac;

"/Users/apple/Documents_Local/RPI/Spring2019/EnsembleNonlinear/KyleSteveGreg/Kyle_Steve_Greg_Ensemble_Nonlinear/samples/hat.wav" => buf1.read;
"/Users/apple/Documents_Local/RPI/Spring2019/EnsembleNonlinear/KyleSteveGreg/Kyle_Steve_Greg_Ensemble_Nonlinear/samples/kick.wav" => buf2.read;
"/Users/apple/Documents_Local/RPI/Spring2019/EnsembleNonlinear/KyleSteveGreg/Kyle_Steve_Greg_Ensemble_Nonlinear/samples/snare.wav" => buf3.read;


fun void inst(int note){
	////////INSTRUMENT PARAMETERS/////////
	
	// HI HAT //
	if (note == 7)
	{
		0 => buf1.pos;
		1.0 => buf1.rate;
		200::ms=>now;	
	}
	// KICK //
	else if (note == 8)
	{
		0 => buf2.pos;
		1.0 => buf2.rate;
		200::ms=>now;
	}
	// SNARE //
	else if (note == 9)
	{
		0 => buf3.pos;
		1.0 => buf3.rate;
		200::ms=>now;
	}
		
}

////////OUR FUNCTIONALITY////////

while(true){
	
	oin => now;
	
	while (oin.recv(msg))
	{
		msg.getFloat(0) => playtog;
		
		
		//depending on the value in the message recieved, play the note in the array
		if( playtog == 7 )
		{
			spork ~ inst(7);
		} 
		else if (playtog == 8)
		{
			spork ~ inst(8);
		}
		else if (playtog == 9)
		{
			spork ~ inst(9);
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