//OscRecv meosc;
//6666 => meosc.port;
//meosc.listen();
//meosc.event( "/playerPositionX, f" ) @=> OscEvent tog1;

OscIn oin;
// create our OSC message
OscMsg msg;
// use port 6449
6666 => oin.port;
// create an address in the receiver
oin.addAddress( "/playerPositionX, f" );



0 => float playtog;
int id[99];

while ( true )
{
    oin => now;
    
    while (oin.recv(msg))
    {
        msg.getFloat(0) => playtog;
        
        <<< playtog >>>;
        
        if( playtog >= 1 )
        {
           // <<< "Hi, I'm in here!!!" >>>;
            //C:\Users\everek\Documents\ChucK\chucK_granulator_tutorial\chucK_granulator_tutorial
            Machine.add( "/Users/everek/Documents/ChucK/chucK_granulator_tutorial/chucK_granulator_tutorial/sampleCloud1a.ck" ) =>  id[0]; 
        }
        else
        {
            //Machine.remove( id[0] ); 
        }
    } 
    1::ms => now;
}
1::day => now;




