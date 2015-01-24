using UnityEngine;
using System.Collections;

public class Minigame : MonoBehaviour {
	private int[] rhythm;
	private AsteroidController newAsteroid;
	private float endPosition = -12;

	void Spawn(Vector3 position, float endposition) {
		GameObject asteroid = GameObject.Instantiate (Resources.Load("Prefabs/Asteroid")) as GameObject;
		newAsteroid = asteroid.GetComponent<AsteroidController> ();
		newAsteroid.transform.position = position;
		newAsteroid.endposition = endposition;
	}

	// Use this for initialization
	void Start () {
		rhythm = new int[]{1, 0, 1, 0};
		int length = rhythm.Length;
		Vector3 spawnOffset = new Vector3(-0.3f, -1f, -0.5f);
		for(int i=0; i < length; i++) {
			if (rhythm[i] == 1) {
				Vector3 spawnPosition = transform.position + spawnOffset;
				spawnPosition.z = spawnPosition.z + i * (spawnPosition.z - endPosition);
				Spawn(spawnPosition, transform.position.z + endPosition);
			}
		}
	}

	
	// Update is called once per frame
	void Update () {
	
	}
}
