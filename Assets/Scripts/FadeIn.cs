using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {
	public float timeDelay;
	public Menu background1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeDelay -= Time.deltaTime;
		if (timeDelay <= 0) {
			background1.transition();
			Destroy(this.gameObject);
				}
	}
}
