Mandolin mand => dac;

25::ms => dur atk;
100::ms => dur dec;
1.0 => float sus;
300::ms => dur rel;

//adsr.set(atk,dec,sus,rel);

int counter;
0.25 => mand.bodySize;
0.5 => mand.pluckPos;
0.5 => mand.stringDamping;
0 => mand.stringDetune;
0.8 => mand.pluck;
mand.controlChange(128, 0.2);



[60,62,64,65,67,69,71,72] @=> int myscale[];

while(true){
    
    //    myfreq + Math.log(100) => myfreq;
    //    myfreq => s.freq;
    
    
    Std.mtof(myscale[counter]-24) => mand.freq;

    
    0.5 => mand.noteOn;
   // adsr.keyOn();
   
    600::ms => now;
	//adsr.keyOff();
	300::ms=> now;
    
    (counter + 1)%8 => counter; //using modulus to prevent index crashing, loop thru scale
    
    
    
}