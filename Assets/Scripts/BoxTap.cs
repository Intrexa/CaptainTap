using System;
using UnityEngine;
using System.Collections;
using TouchScript.Hit;
using TouchScript.Gestures;
using TouchScript.Gestures.Simple;

public enum Direction {right, up, left, down}

public class BoxTap : MonoBehaviour {

	public float swipeThreshold = 0.75f;

	private Vector2 panStart, panEnd;
	private Vector2 panDelta = Vector2.zero;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnEnable()
	{
	    // subscribe to gesture's Tapped event
	    GetComponent<TapGesture>().Tapped += tappedHandler;
	    GetComponent<SimplePanGesture>().Panned += panHandler;
	    GetComponent<SimplePanGesture>().PanStarted += panStartHandler;
	    GetComponent<SimplePanGesture>().PanCompleted += panCompleteHandler;
	}

	void OnDisable()
	{
	    // don't forget to unsubscribe
	    GetComponent<TapGesture>().Tapped -= tappedHandler;
	    GetComponent<SimplePanGesture>().Panned -= panHandler;
	    GetComponent<SimplePanGesture>().PanStarted -= panStartHandler;
	    GetComponent<SimplePanGesture>().PanCompleted -= panCompleteHandler;
	}

	//Process top event
	private void tappedHandler(object sender, EventArgs e)
	{
		Debug.Log("TAPPED: " + gameObject.GetInstanceID());
	}

	//Process Swip event
	//This is a simple swipe, not directional data.
	//TODO: Write custom swipe with direction.
	private void panHandler(object sender, EventArgs e)
	{
		//Debug.Log("PANNING: " + gameObject.GetInstanceID());
	}

	private void panStartHandler(object sender, EventArgs e)
	{
		SimplePanGesture gesture = (SimplePanGesture)sender;
        panStart = gesture.ScreenPosition;
        Debug.Log("PAN STARTED at: "+ panStart);
	}

	private void panCompleteHandler(object sender, EventArgs e)
	{
		SimplePanGesture gesture = (SimplePanGesture)sender;
        panEnd = gesture.ScreenPosition;
        panDelta = panStart - panEnd;
        panDelta.Normalize();
		Debug.Log("PAN COMPLETE at: "+panEnd +" Delta: " + panDelta);
		if(panDelta.x > swipeThreshold)
			swipeHandler(Direction.left);
		else if(panDelta.x < -swipeThreshold)
			swipeHandler(Direction.right);
		else if(panDelta.y > swipeThreshold)
			swipeHandler(Direction.down);
		else if(panDelta.y < -swipeThreshold)
			swipeHandler(Direction.up);

	}

	//Handle a swipe in a direction
	private void swipeHandler(Direction dir)
	{
		switch (dir)
		{
			case Direction.up: 		Debug.Log("Swiped Up");
									break;
			case Direction.down: 	Debug.Log("Swiped Down");
									break;
			case Direction.left: 	Debug.Log("Swiped Left");
									break;
			case Direction.right: 	Debug.Log("Swiped Right");
									break;
		}

	}
}
