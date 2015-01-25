using UnityEngine;
using System.Collections;

public class Minigame : MonoBehaviour {

	public int quad;
	public float width, height;

	public Transform foreground, background;
	private int[] rhythm;
	private float endPosition = -12;

	// Use this for initialization
	void Start () {
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
