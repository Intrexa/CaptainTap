using UnityEngine;
using System.Collections;

public class FirewallMinigame : MonoBehaviour {

	public Minigame minigame;
	public Transform endPosition;
	public float lerpTime;

	private Vector3 startPosition;
	private float lerpStart = -1.0f;
	void Start()
	{
		minigame = transform.parent.GetComponent<Minigame>();
		startPosition = transform.position;
	}

	void Update()
	{
		if(lerpStart > 0)
		{
			transform.position = Vector3.Lerp(startPosition, endPosition.position, (Time.time-lerpStart)/lerpTime);
			if((Time.time-lerpStart)/lerpTime >= 1)
				minigame.GameSuccess(true);
		}
	}

	void OnEnable()
	{
	    // subscribe to gesture's Pan event
	    GetComponent<SwipeHandler>().UpSwipeAction += UpSwipe;
	    GetComponent<SwipeHandler>().DownSwipeAction += DownSwipe;
	    GetComponent<SwipeHandler>().LeftSwipeAction += LeftSwipe;
	    GetComponent<SwipeHandler>().RightSwipeAction += RightSwipe;
	}

	void OnDisable()
	{
	    // subscribe to gesture's Pan event
	    GetComponent<SwipeHandler>().UpSwipeAction -= UpSwipe;
	    GetComponent<SwipeHandler>().DownSwipeAction -= DownSwipe;
	    GetComponent<SwipeHandler>().LeftSwipeAction -= LeftSwipe;
	    GetComponent<SwipeHandler>().RightSwipeAction -= RightSwipe;
	}

	private void DownSwipe()
	{
		minigame.GameFail();
	}

	private void UpSwipe()
	{
		minigame.GameFail();
	}

	private void LeftSwipe()
	{
		minigame.GameFail();
	}

	private void RightSwipe()
	{
		lerpStart = Time.time;
	}
}
