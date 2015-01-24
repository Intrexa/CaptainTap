using UnityEngine;
using System.Collections;

public class AsteroidControl : MonoBehaviour {

	public int quad;
	public float width, height;
	
	public Transform foreground, background;
	private int[] rhythm;
	private AsteroidController newAsteroid;
	private float endPosition = -12;
	
	void Spawn(Vector3 position, float endposition, int rhythmIndex) {
		GameObject asteroid = GameObject.Instantiate (Resources.Load("Prefabs/Asteroid")) as GameObject;
		newAsteroid = asteroid.GetComponent<AsteroidController> ();
		newAsteroid.transform.position = position;
		newAsteroid.endposition = endposition;
		newAsteroid.rhythmIndex = rhythmIndex; 
	}
	
	// Use this for initialization
	void Start () {
		rhythm = new int[]{1, 0, 1, 0};
		int length = rhythm.Length;
		Vector3 spawnOffset = new Vector3(-0.3f, -1f, -0.5f);
		for(int rhythmIndex=0; rhythmIndex < length; rhythmIndex++) {
			if (rhythm[rhythmIndex] == 1) {
				Vector3 spawnPosition = transform.position + spawnOffset;
				spawnPosition.z = spawnPosition.z + rhythmIndex * (spawnPosition.z - endPosition);
				//Spawn(spawnPosition, transform.position.z + endPosition, rhythmIndex);
			}
		}
		Debug.Log("test");
		//Move foreground and background
		if (foreground)
			foreground.position = new Vector3(foreground.position.x,foreground.position.y,Camera.main.nearClipPlane);
		
		if (background)
			background.position = new Vector3(background.position.x,background.position.y,Camera.main.farClipPlane-100);
	}
	
	
	// Update is called once per frame
	void Update () {
		
	}
	
}