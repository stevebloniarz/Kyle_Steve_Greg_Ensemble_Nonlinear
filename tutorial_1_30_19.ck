
/*
SinOsc s;
s => dac; //chuck our SinOsc s to a digital to analog converter

1.0 => s.gain;
100 => float myfreq;

*/

Mandolin m => dac;
1.0 => m.bodySize;
1.0 => m.pluckPos;


int counter;
[60,62,64,65,67,69,71,72] @=> int myscale[];

while(true){
    
//    myfreq + Math.log(100) => myfreq;
//    myfreq => s.freq;


    Std.mtof(myscale[counter]) => m.freq;
    1.0 => m.pluck;

    1000::ms => now;
    
    (counter + 1)%8 => counter; //using modulus to prevent index crashing, loop thru scale


    
}
