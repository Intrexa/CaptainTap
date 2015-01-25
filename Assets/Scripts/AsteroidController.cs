using UnityEngine;
using System.Collections;

public class AsteroidController : MonoBehaviour {
	public ShipMovement ship;
	public SwipeHandler background;

	private float[] endTimes;
	private Object AsteroidPrefab;
	private AsteroidActions newAsteroid;
	private Vector3 startPos;
	private float currentTime;
	private float starttime;
	private float nexttime;
	private int noteIndex;

	private Minigame minigame;
	// Use this for initialization
	void Start () {
		if (!ship) {
			Debug.Log ("Must set ship field in inspector!");
		}

		if (!background) {
			Debug.Log ("Must set ship field in inspector!");
		}
		minigame = transform.parent.GetComponent<Minigame>();
		AsteroidPrefab = Resources.Load ("Prefabs/Asteroid");
		startPos = transform.position;
		noteIndex = 0;
		endTimes = new float[] {minigame.arrivalTime};//new float[] {2,5,10,15};
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
		asteroid.transform.localPosition = startPos;
		asteroid.transform.parent = transform.parent;
		asteroid.transform.localScale = Vector3.one * 0.1f;
		newAsteroid = asteroid.GetComponent<AsteroidActions> ();
		newAsteroid.setEndTime(endtime+minigame.gamePanel.goodThreshold);

		minigame.GenerateHints();

	}

	void KillMinigame() {
		gameObject.SetActive(false);//cleanup
	}
}
