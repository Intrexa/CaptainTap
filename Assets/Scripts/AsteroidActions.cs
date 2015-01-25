using UnityEngine;
using System.Collections;

public class AsteroidActions : MonoBehaviour {

	private float starttime;
	private float endtime;
	private float currenttime;
	private Vector3 startPos;
	private Vector3 endPos;
	private Vector3 startScale;
	private Vector3 endScale;
	private Vector3 positionOffset;

	public void setStartTime(float y) {
				starttime = y;
		}

	public void setEndTime(float t) {
		endtime = t;
	}

	// Use this for initialization
	void Start () {
		currenttime = Time.time;
		endPos = startPos + new Vector3 (2, 2, 0);
		Debug.Log (startPos);
		startScale = transform.localScale;
		endScale = transform.localScale * 10;
	}

	// Update is called once per frame
	void Update () {
		currenttime = Time.time;
		transform.position = Vector3.MoveTowards(startPos, endPos, currenttime/endtime);
		transform.localScale = Vector3.Lerp(startScale, endScale, currenttime/endtime);

		if (currenttime >= endtime) {
			Strike(); 
				}

	}

	void Strike() {
		Destroy(this.gameObject);
	}


}
