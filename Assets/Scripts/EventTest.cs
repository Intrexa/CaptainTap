using UnityEngine;
using System.Collections;

public class EventTest : MonoBehaviour {

	void OnEnable()
	{
	    // subscribe to gesture's Pan event
	    GetComponent<TapHandler>().TapAction += TappedTest;
	    GetComponent<SwipeHandler>().UpSwipeAction += UpSwipeTest;
	    GetComponent<SwipeHandler>().DownSwipeAction += DownSwipeTest;
	    GetComponent<SwipeHandler>().LeftSwipeAction += LeftSwipeTest;
	    GetComponent<SwipeHandler>().RightSwipeAction += RightSwipeTest;
	}

	void OnDisable()
	{
	    // subscribe to gesture's Pan event
	    GetComponent<TapHandler>().TapAction -= TappedTest;
	    GetComponent<SwipeHandler>().UpSwipeAction -= UpSwipeTest;
	    GetComponent<SwipeHandler>().DownSwipeAction -= DownSwipeTest;
	    GetComponent<SwipeHandler>().LeftSwipeAction -= LeftSwipeTest;
	    GetComponent<SwipeHandler>().RightSwipeAction -= RightSwipeTest;
	}

	private void TappedTest()
	{
		Debug.Log("TAPPED TEST EVENT");
	}

	private void DownSwipeTest()
	{
		Debug.Log("DOWN SWIPE TEST EVENT");
	}

	private void UpSwipeTest()
	{
		Debug.Log("UP SWIPE TEST EVENT");
	}

	private void LeftSwipeTest()
	{
		Debug.Log("LEFT SWIPE TEST EVENT");
	}

	private void RightSwipeTest()
	{
		Debug.Log("RIGHT SWIPE TEST EVENT");
	}


}
