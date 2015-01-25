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
	private float RandVal = Random.value;
	private Vector3 spin;
	private Minigame minigame;

	void OnEnable()
	{
		// subscribe to gesture's Pan event
		GetComponent<TapHandler>().TapAction += Tapped;
	}
	
	void OnDisable()
	{
		// subscribe to gesture's Pan event
		GetComponent<TapHandler>().TapAction -= Tapped;
	}


	public void setEndTime(float t) {
		endtime = t+1;
	}

	// Use this for initialization
	void Start () {
		currenttime = Time.time;
		startPos = Vector3.one;
		Vector3 offset = new Vector3 (2.5f, 1.5f, 0.0f);
		spin = new Vector3 (0, 0, 8 * Random.Range (-1.0f, 1.0f));


		// Randomly set position to a quadrant
		if (Mathf.Round (Random.value) == 0.0f)
			offset.x *= -1;
		if (Mathf.Round (Random.value) == 0.0f)
			offset.y *= -1;

		endPos = startPos + offset;

		startScale = Vector3.one * 0.1f;
		endScale = transform.localScale * 16;
		startTime = Time.time;
		minigame = transform.parent.GetComponent<Minigame>();
	}

	// Update is called once per frame
	void Update () {
		currenttime = Time.time;
		float t = (currenttime - startTime) / (endtime - startTime);
		transform.localPosition = Vector3.Lerp(startPos, endPos, t);
		transform.localScale = Vector3.Lerp(startScale, endScale, t);
		transform.Rotate (spin);
		if (currenttime >= endtime) {
			Strike(); 
		}

	}

	void Strike() {
		Destroy(this.gameObject);
		transform.localPosition = startPos;
		transform.localScale = Vector3.one;
	}

	void Tapped() {
		if (Mathf.Abs (Time.time - endtime) < 1) {
			minigame.GameSuccess(true);

		} else {
			minigame.GameSuccess(false);
		}
		minigame.GameDestroy();
	}
}
