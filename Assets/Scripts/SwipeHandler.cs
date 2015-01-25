using System;
using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using TouchScript.Gestures.Simple;

[RequireComponent (typeof (SimplePanGesture))]
public class SwipeHandler : MonoBehaviour {

	public float swipeThreshold = 0.75f;
	public bool debugLog = true;

	public delegate void UpSwiped();
    public event UpSwiped UpSwipeAction; 

    public delegate void DownSwiped();
    public event DownSwiped DownSwipeAction; 

    public delegate void LeftSwiped();
    public event LeftSwiped LeftSwipeAction; 

    public delegate void RightSwiped();
    public event RightSwiped RightSwipeAction; 

	private Vector2 panStart, panEnd;	
	private Vector2 panDelta = Vector2.zero;

	void OnEnable()
	{
	    // subscribe to gesture's Pan event
	    GetComponent<SimplePanGesture>().Panned += panHandler;
	    GetComponent<SimplePanGesture>().PanStarted += panStartHandler;
	    GetComponent<SimplePanGesture>().PanCompleted += panCompleteHandler;
	}

	void OnDisable()
	{
	    GetComponent<SimplePanGesture>().Panned -= panHandler;
	    GetComponent<SimplePanGesture>().PanStarted -= panStartHandler;
	    GetComponent<SimplePanGesture>().PanCompleted -= panCompleteHandler;
	}

	//Process pan events
	private void panHandler(object sender, EventArgs e)
	{
		//print("PANNING: " + gameObject.GetInstanceID());
	}

	//Store pan start position
	private void panStartHandler(object sender, EventArgs e)
	{
		SimplePanGesture gesture = (SimplePanGesture)sender;
        panStart = gesture.ScreenPosition;
        if(debugLog)
        	print("PAN STARTED on: " + gameObject.name + " at "+ panStart);
	}

	//Pan ended: Find direction of of pan and call swipeHandler
	private void panCompleteHandler(object sender, EventArgs e)
	{
		SimplePanGesture gesture = (SimplePanGesture)sender;
        panEnd = gesture.ScreenPosition;
        panDelta = panStart - panEnd;
        panDelta.Normalize();

        if(debugLog)
			print("PAN COMPLETE on: " + gameObject.name + " at "+panEnd +" delta: " + panDelta);

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
			case Direction.up: 		print("Swiped Up");
									try {
										UpSwipeAction();}
									catch (NullReferenceException error)
									{
										Debug.LogWarning("Swiped Up has no registered event");
									}
									break;
			case Direction.down: 	print("Swiped Down");
									try {
										DownSwipeAction();}
									catch (NullReferenceException error)
									{
										Debug.LogWarning("Swiped Down has no registered event");
									}
									break;
			case Direction.left: 	print("Swiped Left");
									try {
										LeftSwipeAction();}
									catch (NullReferenceException error)
									{
										Debug.LogWarning("Swiped Left has no registered event");
									}
									break;
			case Direction.right: 	print("Swiped Right");
									try {
										RightSwipeAction();}
									catch (NullReferenceException error)
									{
										Debug.LogWarning("Swiped Right has no registered event");
									}
									break;
		}
	}

	private void print(string message)
	{
		if(debugLog)
			Debug.Log(message);
	}
}
