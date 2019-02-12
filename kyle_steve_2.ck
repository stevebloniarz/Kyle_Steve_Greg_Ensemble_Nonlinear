Wurley wurl => dac;


int counter;
0.8 => wurl.gain;
0.80 => wurl.afterTouch;
0.2 => wurl.controlOne;
0.15 => wurl.controlTwo;
//9=> wurl.lfoSpeed;
//0.25=> wurl.lfoDepth;

//2 => wurl.phonemeNum;
//1.0 => wurl.voiceMix;
//10 => wurl.vibratoFreq;



[60,62,64,65,67,69,71,72] @=> int myscale[];

while(true){
    
    //    myfreq + Math.log(100) => myfreq;
    //    myfreq => s.freq;
    
    
    Std.mtof(myscale[counter]) => wurl.freq;
    Std.mtof(myscale[counter]) => wurl.freq;
    Std.mtof(myscale[counter]) => wurl.freq;
    
    0.5 => wurl.noteOn;
    
    
    repeat( 10 )
    {
        wurl.freq() * 1.01 => wurl.freq;
        5::ms => now;
    }
    
    300::ms => now;
    
    (counter + 1)%8 => counter; //using modulus to prevent index crashing, loop thru scale
    
    
    
}