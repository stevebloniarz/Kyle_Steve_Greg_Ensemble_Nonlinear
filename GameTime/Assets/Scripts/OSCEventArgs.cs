using UnityEngine;
using System; 
using System.Collections.Generic; 
using OSCsharp.Data; 
using OSCsharp.Net; 
using OSCsharp.Utils; 

public class OSCEventArgs : EventArgs { 

	public string myCustomVar;

	public OSCEventArgs(string myCustomVar)
	{
		Debug.Log ("TTEEESSTTTT");

		//Cursor = myCustomVar;
	}
}