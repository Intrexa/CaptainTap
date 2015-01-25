using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	public Material newMenu;


	// Use this for initialization
	void Start () {
		GetComponent<TapHandler>().TapAction += loadLevel;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void loadLevel(){
		Debug.Log ("test");

		Application.LoadLevel ("Panel Testing");

		}

	public void transition(){
		renderer.material = newMenu;
		}
}
