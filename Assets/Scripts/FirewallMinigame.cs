using UnityEngine;
using System.Collections;

public class FirewallMinigame : MonoBehaviour {

	public Minigame minigame;
	public Transform startPosition;
	public Transform endPosition;
	public float lerpTime;

	private bool perfect = false;
	private float lerpStart = -1.0f;
	void Start()
	{
		minigame = transform.parent.GetComponent<Minigame>();
	}

	void Update()
	{
		if(lerpStart > 0)
		{
			transform.position = Vector3.Lerp(startPosition.position, endPosition.position, (Time.timeSinceLevelLoad-lerpStart)/lerpTime);
			if((Time.timeSinceLevelLoad-lerpStart)/lerpTime >= 1)
				minigame.GameDestroy();
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
		if(Time.timeSinceLevelLoad - minigame.arrivalTime >= 1.5f - minigame.gamePanel.perfectThreshold )
				minigame.GameSuccess(true);
		else
			minigame.GameSuccess(false);
		lerpStart = Time.timeSinceLevelLoad;
	}
}
