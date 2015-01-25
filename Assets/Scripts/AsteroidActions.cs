using UnityEngine;
using System.Collections;

public class AsteroidActions : MonoBehaviour {
	
	private float endtime;
	private float currenttime;
	private Vector3 startPos;
	private Vector3 endPos;
	private Vector3 startScale;
	private Vector3 endScale;
	private Vector3 positionOffset;
	private float startTime;
	void OnEnable()
	{
		// subscribe to gesture's Pan event
		GetComponent<TapHandler>().TapAction += TappedTest;
	}
	
	void OnDisable()
	{
		// subscribe to gesture's Pan event
		GetComponent<TapHandler>().TapAction -= TappedTest;
	}


	public void setEndTime(float t) {
		endtime = t;
	}

	// Use this for initialization
	void Start () {
		currenttime = Time.time;
		startPos = Vector3.one;
		endPos = startPos + new Vector3 (3, 2, 0);
		startScale = Vector3.one * 0.1f;
		endScale = transform.localScale * 8;
		startTime = Time.time;
	}

	// Update is called once per frame
	void Update () {
		currenttime = Time.time;
		transform.position = Vector3.Lerp(startPos, endPos, (currenttime- startTime)/(endtime - startTime));
		transform.localScale = Vector3.Lerp(startScale, endScale, (currenttime- startTime)/(endtime - startTime));
		if (currenttime >= endtime) {
			Strike(); 
		}

	}

	void Strike() {
		Destroy(this.gameObject);
		transform.position = startPos;
		transform.localScale = Vector3.one;
	}

	public void TappedTest() {
		if (Mathf.Abs (Time.time - endtime) < 1) {
			Hit ();
		} else {
			Debug.Log ("Miss");
		}
	}

	void Hit() {
		Debug.Log ("Hit");
		Destroy (this.gameObject);
	}
}
