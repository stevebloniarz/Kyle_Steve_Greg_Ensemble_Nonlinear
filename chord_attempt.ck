// Sound Network
Wurley chord[3];

for (0 => int i; i < chord.cap(); i++)
{
    chord[i] => dac; // use array to chuck Unit Generator to DAC
    
    0.3 => chord[i].gain; // Set Volume so no Peaking
    0.80 => chord[i].afterTouch;
    0.1 => chord[i].controlOne;
    0.05 => chord[i].controlTwo;
   
}


// Function
fun void playChord(int root, string quality, float length)
{
    // function will make Major or Minor Chords
    
    //root
    Std.mtof(root) => chord[0].freq;
    
    // third
    if (quality == "major")
    {
        Std.mtof(root+4) => chord[1].freq; // major interval
    }
    else if (quality == "minor")
    {
        Std.mtof(root+3) => chord[1].freq; // minor interval
    }
    
    // fifth
    Std.mtof(root+7) => chord[2].freq;
    
    
    //turn the note on
    for(0=>int i; i< 3; i++)  
    {
            
       1 => chord[i].noteOn;
   
    }
    
    //chord pitch bend
    // +50ms
    repeat(10)  
    {
        
        chord[0].freq() * 1.01 => chord[0].freq;
        chord[1].freq() * 1.01 => chord[1].freq;
        chord[2].freq() * 1.01 => chord[2].freq;
        5::ms => now;
        
    }
    
    length::ms => now;
    
}

// Main Program
while (true)
{
    // Procedurally play through 3 chords: minor, major, minor
    playChord(Std.rand2(60,72), "major", 1000.0);
    playChord(Std.rand2(60,72), "major", 1000.0);
    playChord(Std.rand2(60,72), "minor", 2000.0);
}