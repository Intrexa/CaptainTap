using UnityEngine;
using System.Collections;

public class ShipMovement : MonoBehaviour {
	bool crashing;
	bool dodgeUp;
	bool waiting;
	float speed = 0.7f;
	float topPos = 4.3f;
	float bottomPos = -3.8f;
	Vector3 startPos;
	float currenttime;

	public void DodgeUp(bool swipeDirection) {
		waiting = false;
		dodgeUp = swipeDirection;
	}
	public void crash() {
		crashing = true;
	}

	void MoveUp() {
		transform.Translate (0, speed, 0);
		if (transform.position.y > topPos) {
			waiting = true; 
		}
	}
	
	void MoveDown() {
		transform.Translate (0, -speed, 0);
		if (transform.position.y < bottomPos) {
			waiting = true;
		}
	}

	void MovetoCenter() {
			transform.position = Vector3.MoveTowards(transform.position, startPos, 0.1f);
	}

	// Use this for initialization
	void Start () {
		startPos = transform.position;
		crashing = false;
		waiting = true;
		currenttime = 0;
	}
	
	// Update is called once per frame
	void Update () {
			currenttime += Time.deltaTime;
			if (!crashing) {
				if (!waiting) {
					if (dodgeUp) {
						MoveUp();
					} else {
						MoveDown();
					}
				} else {
					MovetoCenter();
			}
		}
	}
}

