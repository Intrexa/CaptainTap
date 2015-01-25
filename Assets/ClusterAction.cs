using UnityEngine;
using System.Collections;

public class ClusterAction : MonoBehaviour {
	private Vector3 startPos;
	private float endPos = 2;
	private Vector3 offset;
	private bool crash;
	public int speed;
	// Use this for initialization
	void Start () {
		crash = false;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (-speed, 0, 0);

		if (transform.position.x <= endPos) {
			destroy ();
		}
	}

	void onTriggerEnter(Collider ship) {
		Debug.Log ("Ship: collide");
	}

	void destroy() {
		Destroy (gameObject);
	}
}
