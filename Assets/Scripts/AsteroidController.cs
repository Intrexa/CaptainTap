﻿using UnityEngine;
using System.Collections;

public class AsteroidController : MonoBehaviour {
	private float[] endTimes;
	private Object AsteroidPrefab;
	private AsteroidActions newAsteroid;
	private Vector3 startPos;
	private float currentTime;
	private float starttime;
	private float nexttime;
	private int noteIndex;
	// Use this for initialization
	void Start () {
		AsteroidPrefab = Resources.Load ("Prefabs/Asteroid");
		startPos = transform.position;
		noteIndex = 0;
		endTimes = new float[] {2,5,10,15};
		starttime = endTimes [noteIndex] - 2;
		//nexttime = Time.time;
		currentTime = Time.time;
		//for (int i=0; i<endTimes.Length; i++) {
		//	SpawnAsteroid(startPos, starttime, endTimes[i]);
		//}
	}
	
	// Update is called once per frame
	void Update () {
		currentTime = Time.time;
		if (currentTime >= starttime) {
			SpawnAsteroid (startPos, endTimes [noteIndex++]);
			if (noteIndex < endTimes.Length) {
				starttime = endTimes [noteIndex] - 2;
			} else {
				KillMinigame ();
			}
		}
	}

	void SpawnAsteroid(Vector3 startPos, float endtime)
	{

		GameObject asteroid = GameObject.Instantiate (AsteroidPrefab) as GameObject;
		asteroid.transform.position = startPos;
		newAsteroid = asteroid.GetComponent<AsteroidActions> ();
		newAsteroid.setEndTime(endtime);

	}

	void KillMinigame() {
		gameObject.SetActive(false);//cleanup
	}
}
