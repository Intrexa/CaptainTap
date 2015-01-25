using UnityEngine;
using System.Collections;

public class AvoidController : MonoBehaviour {
	private bool swipeUp = false;

	public ShipMovement ship;
	
	private float[] endTimes;
	private Object ClusterPrefab;
	private ClusterAction newCluster;
	private Vector3 startPos;
	private float currentTime;
	private float starttime;
	private float nexttime;
	private int noteIndex;
	// Use this for initialization
	void Start () {



		ClusterPrefab = Resources.Load ("Prefabs/Cluster");
		startPos = transform.position;
		startPos = new Vector3 (28, 0, 0);
		noteIndex = 0;
		endTimes = new float[] {1, 5, 8};
	}
	
	// Update is called once per frame
	void Update () {
		currentTime = Time.time;
		if (currentTime >= starttime) {
			Vector3 verticalOffset = Vector3.down * -4.25f;
			if (Random.value < .5) {
				swipeUp = true;
				verticalOffset.y *= -1;
			}
			ship.DodgeUp (swipeUp);
			SpawnCluster (startPos);
			SpawnCluster (startPos + verticalOffset);
			if (noteIndex < endTimes.Length) {
				starttime = endTimes [noteIndex++];
			}
			else {
				gameObject.SetActive(false);
			}
		}
	}

	void SpawnCluster(Vector3 startPos)
	{
		GameObject cluster = GameObject.Instantiate (ClusterPrefab) as GameObject;
		cluster.transform.position = startPos;
		newCluster = cluster.GetComponent<ClusterAction> ();

	}
}
