using UnityEngine;
using System.Collections;

public class GamePanel : MonoBehaviour {

	public Minigame[] minigameArray;

	// Use this for initialization
	void Start () {
		//Create Minigames
		for(int i = 0; i < 4; i++)
			minigameArray[i] = new Minigame();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

public class Minigame
{

}
