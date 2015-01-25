using UnityEngine;
using System.Collections;

public class AvoidController : MonoBehaviour {
	private bool swipeUp = false;

	public ShipMovement ship;
	public SwipeHandler background;

	public float spawnTiming = 2;

	private float[] endTimes;
	private Object AvoidGroupPrefab;

	private Object HintPrefab;
	private AvoidSwipeAction newHint;
	private Vector3 startPos;
	private float currentTime;
	private float starttime;
	private float nexttime;
	private int noteIndex;
	// Use this for initialization
	void Start () {
		if (!ship) {
			Debug.Log ("Must set ship field in inspector!");
		}
		
		if (!background) {
			Debug.Log ("Must set background field in inspector!");
		}

		starttime = Time.timeSinceLevelLoad; 
		HintPrefab = Resources.Load ("Prefabs/Hint");
		startPos = transform.localPosition;
		startPos = new Vector3 (0, 0, 12);
		noteIndex = 0;
		endTimes = new float[] {5, 9, 11};
		nexttime = endTimes [0];
		if (nexttime - starttime < spawnTiming) {
			starttime = nexttime;
		} else {
			starttime = nexttime - spawnTiming;
		}
	}
	
	// Update is called once per frame
	void Update () {
		currentTime = Time.timeSinceLevelLoad;
		Vector3 verticalOffset = Vector3.up * 4.25f;
		swipeUp = false;
		//Debug.Log ("NOW: " + currentTime + " ETA:" + nexttime);
		if (currentTime >= starttime) {
			if (Random.value < .5) {
				swipeUp = true;
				verticalOffset = Vector3.down * 4.25f;
			}

			SpawnHint(nexttime);
			Debug.Log (noteIndex);
			if (noteIndex < endTimes.Length - 1) {
				nexttime = endTimes[++noteIndex];
				if (nexttime - currentTime > spawnTiming) { 
					starttime = nexttime - spawnTiming;
				} else {
					starttime = nexttime;
				}
			} else {
				this.enabled = false;
			}
		}
	}

	void SpawnHint(float endTime) {
		GameObject hint = GameObject.Instantiate (HintPrefab) as GameObject;
		hint.transform.localPosition = startPos;
		hint.transform.parent = transform;
		newHint = hint.GetComponent<AvoidSwipeAction> ();
		newHint.setShip (ship);
		newHint.setBackground (background);
		newHint.setEndTime(endTime);
		newHint.setDirection (swipeUp);

	}

}
