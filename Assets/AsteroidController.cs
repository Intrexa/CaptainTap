using UnityEngine;
using System.Collections;

public class AsteroidController : MonoBehaviour {

	private float speed = 0.1875f;
	public float startsize;
	public float endsize;
	public float beat = 0.046875f;
	public float startposition;
	public float endposition; 
	public int rhythmIndex; 

	// Use this for initialization
	void Start () {

	}
	// Update is called once per frame
	void Update() {
		transform.localScale = Vector3.one * (Vector3.Distance (transform.position, transform.parent.position)
		/ Vector3.Distance (transform.position, Camera.main.transform.position));
		//start position: 	2.6, 1.7, -1.6
		//end position: -0.3, -1, -1.6
		//start scale: 0.5,0.5,0.5
		//end scale: 8, 8, 8 

		Vector3.MoveTowards(transform.position, transform.position + transform.forward * endposition, rhythmIndex*beat); 
		startposition = transform.localPosition.x ;
		if (startposition <= endposition) 
		{
			destroy(); 
		}
		transform.Translate (0, 0, -1);
	}

	void destroy() {
		Destroy (transform.gameObject);
		//start destroy animation
		//remove itself
	}
}
