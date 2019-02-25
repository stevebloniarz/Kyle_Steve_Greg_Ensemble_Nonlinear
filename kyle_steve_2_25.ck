BlowHole hole => ADSR adsr => dac;

25::ms => dur atk;
100::ms => dur dec;
1.0 => float sus;
300::ms => dur rel;

adsr.set(atk,dec,sus,rel);

int counter;
0.53 => hole.reed;
//0.20 => hole.noiseGain;
//0.476 => hole.tonehole;
//0.2 => hole.vent;
//0.115 => hole.pressure;
//9=> hole.lfoSpeed;
//0.25=> hole.lfoDepth;

//2 => hole.phonemeNum;
//1.0 => hole.voiceMix;
//10 => hole.vibratoFreq;



[60,62,64,65,67,69,71,72] @=> int myscale[];

while(true){
    
    //    myfreq + Math.log(100) => myfreq;
    //    myfreq => s.freq;
    
    
    Std.mtof(myscale[counter]-24) => hole.freq;

    
    0.5 => hole.noteOn;
    adsr.keyOn();
   
    600::ms => now;
	adsr.keyOff();
	300::ms=> now;
    
    (counter + 1)%8 => counter; //using modulus to prevent index crashing, loop thru scale
    
    
    
}