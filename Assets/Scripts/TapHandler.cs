using System;
using UnityEngine;
using System.Collections;
using TouchScript.Gestures;

[RequireComponent (typeof (TapGesture))]
public class TapHandler : MonoBehaviour {

	public bool debugLog = true;

	public delegate void Tapped();
    public event Tapped TapAction; 

	void OnEnable()
	{
	    // subscribe to gesture's Tapped event
	    GetComponent<TapGesture>().Tapped += tappedHandler;
	}

	void OnDisable()
	{
	    // don't forget to unsubscribe
	    GetComponent<TapGesture>().Tapped -= tappedHandler;
	}

	//Process top event
	private void tappedHandler(object sender, EventArgs e)
	{	
		if(debugLog)
			print("TAPPED: " + gameObject.name);

		TapAction();
	}
	
	private void print(string message)
	{
		if(debugLog)
			Debug.Log(message);
	}
}
