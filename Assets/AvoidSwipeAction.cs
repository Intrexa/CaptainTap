using UnityEngine;
using System.Collections;

public class AvoidSwipeAction : MonoBehaviour {
	//The following are set by controller spawning
	private SwipeHandler background; 
	private ShipMovement ship;
	private bool swipeUp;

	private float endTime;
	private float currenttime;
	private Object ClusterPrefab;
	private ClusterAction newCluster;
	private Vector3 spawnPos;
	private Vector3 spawnOffset;
	private bool swiped;

	public void setBackground(SwipeHandler fromController) {
		background = fromController;
	}

	public void setShip(ShipMovement fromController) {
		ship = fromController;
	}

	public void setEndTime(float t) {
		endTime = t;
	}

	public void setDirection(bool isUp) {
		swipeUp = isUp;
	}

	void Awake() {
		ClusterPrefab = Resources.Load ("Prefabs/Cluster");
	}

	void OnDisable () {
		if (swipeUp) {
			background.UpSwipeAction -= Swiped; 
		} else {
			background.DownSwipeAction -= Swiped;
		}
	}

	// Use this for initialization
	void Start () {
		spawnPos = new Vector3 (28, 0, 0) + transform.localPosition;
		spawnOffset = Vector3.down * 4.25f;
		if (!swipeUp) {
			background.DownSwipeAction += Swiped;
			transform.Rotate (0, 0, 180);
			spawnOffset = Vector3.up * 4.25f;
		} else {
			background.UpSwipeAction += Swiped;
		}
	}
	
	// Update is called once per frame
	void Update () {
		currenttime = Time.timeSinceLevelLoad;

		if (currenttime >= endTime) {
			if (swiped) {
				Success();
			} else {
				Fail ();
			}
		}
	}

	
	void SpawnCluster(Vector3 startPos)
	{
		GameObject cluster = GameObject.Instantiate (ClusterPrefab) as GameObject;
		Debug.Break();
		cluster.transform.localPosition = startPos;
		newCluster = cluster.GetComponent<ClusterAction> ();
		cluster.transform.parent = transform.parent;
	}

	void Success() {
		Debug.Log ("Avoid Success");
		ship.DodgeUp (swipeUp);
		Finish ();
	}

	void Fail () {
		Debug.Log ("Failed Avoid");
		ship.crash ();
		Finish ();
	}

	void Finish() {
		SpawnCluster(spawnPos);
		SpawnCluster (spawnPos + spawnOffset);
		Destroy ();
	}

	void Swiped() {
		AnimateSwiped ();
		if (endTime - Time.timeSinceLevelLoad < 2) {
			swiped = true;
			Debug.Log ("Good Swipe");
		} else {
			Debug.Log ("Bad Swipe");
		}
	}

	void AnimateSwiped () {
		renderer.enabled = false;
	}

	void Destroy() {
		Destroy (gameObject);
	}
}
