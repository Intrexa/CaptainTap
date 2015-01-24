using UnityEngine;
using System.Collections;

public class GamePanel : MonoBehaviour {

	public Minigame[] minigameArray;
	public GameObject tempMiniGame;
	public float panelZDistance;
	private Vector3[] miniGamePositions;
	// Use this for initialization
	void Start () {

		//Find Centre points of Quadrants;
		miniGamePositions = new Vector3[4];
		miniGamePositions[0] = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width*0.25f), (Screen.height*0.25f), Camera.main.nearClipPlane+panelZDistance));//new Vector3((Screen.width*0.25f),transform.y,(Screen.height*0.25f));
		miniGamePositions[1] = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width*0.25f)*3, (Screen.height*0.25f), Camera.main.nearClipPlane+panelZDistance));//new Vector3((Screen.width*0.25f),transform.y,(Screen.height*0.25f));
		miniGamePositions[2] = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width*0.25f)*3, (Screen.height*0.25f)*3, Camera.main.nearClipPlane+panelZDistance));//new Vector3((Screen.width*0.25f),transform.y,(Screen.height*0.25f));
		miniGamePositions[3] = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width*0.25f), (Screen.height*0.25f)*3, Camera.main.nearClipPlane+panelZDistance));//new Vector3((Screen.width*0.25f),transform.y,(Screen.height*0.25f));

		//Create Minigames
		minigameArray = new Minigame[4];
		for(int i = 0; i < 4; i++){
			createMinigame(i);
		}
	}
	
	// Update is called once per frame
	void Update () {
	foreach(Vector3 v in miniGamePositions)
			Debug.DrawLine(v, v+Vector3.forward);
	}

	private void DestroyMinigame(int quad)
	{
		DestroyImmediate(minigameArray[quad].transform);
	}

	private void createMinigame(int quad)
	{	
		//GameObject newGame = //Score.GetNewMiniGame();
		GameObject newGO = Instantiate(tempMiniGame, miniGamePositions[quad],tempMiniGame.transform.rotation) as GameObject;
		newGO.renderer.material.color = new Color(Random.value,Random.value,Random.value);
		newGO.transform.parent = transform;
		minigameArray[quad] = newGO.GetComponent<Minigame>() as Minigame;
		minigameArray[quad].quad = quad;
		minigameArray[quad].width = Screen.width*0.5f;
		minigameArray[quad].height = Screen.height*0.5f;
	}
}


