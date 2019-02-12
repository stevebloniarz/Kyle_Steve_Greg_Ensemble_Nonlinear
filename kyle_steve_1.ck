OscIn oin;
// create our OSC message
OscMsg msg;
// use port 6449
12322 => oin.port;
// create an address in the receiver
oin.addAddress( "/1/push1, f" );

0 => float playtog;

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

[64,64,64,60,64,67] @=> int myscale[];

while(true){
	
	oin => now;
	
	while (oin.recv(msg))
	{
		msg.getFloat(0) => playtog;
		if( playtog == 1 )
		{
			Std.mtof(myscale[counter]) => rhode.freq;
			0.5 => rhode.noteOn;
			adsr.keyOn();
			
			100::ms => now;
			
			adsr.keyOff();
			
			//300::ms => now;
			
			(counter + 1)%6 => counter; //using modulus to prevent index crashing, loop thru scale	
			
		} 
		1::ms => now;
	}
	
	
}