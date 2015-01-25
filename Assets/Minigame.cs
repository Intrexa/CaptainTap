using UnityEngine;
using System.Collections;

public class Minigame : MonoBehaviour {

	public int quad;
	public float width, height;

	public Transform foreground, background;
	public float arrivalTime;

	public float fullScale;
	private int[] rhythm;
	private float totalTime;
	private Vector3 startPosition;
	private GamePanel gamePanel;
	// Use this for initialization
	void Start () {
		gamePanel = transform.parent.GetComponent<GamePanel>();
		rhythm = new int[]{1, 0, 1, 0};
		startPosition = transform.position;
		totalTime = arrivalTime - Time.time;

		//Move foreground and background
		if (foreground)
			foreground.position = new Vector3(foreground.position.x,foreground.position.y,Camera.main.nearClipPlane);

		if (background)
			background.position = new Vector3(background.position.x,background.position.y,500);
	}

	
	// Update is called once per frame
	void Update () {
		float timeLeft = arrivalTime - Time.time;

		//If the has elapsed fail
		if(timeLeft + gamePanel.goodThreshold <= 0)
		{
			GameFail();
			return;
		}

		//Position based on time remaining and spawn distance
		transform.position = Vector3.Lerp(startPosition + new Vector3(0,0,totalTime*gamePanel.spawnDistance), startPosition,Mathf.Pow(1-timeLeft/totalTime,gamePanel.speed)); //-(gamePanel.speed/2)+(1-timeLeft/totalTime)*gamePanel.speed
		//Set the scale based on z position
		transform.localScale = new Vector3(fullScale,fullScale,0) *(Vector3.Distance(startPosition, transform.parent.position)/Vector3.Distance(transform.position, transform.parent.position)) + new Vector3(0,0,fullScale);			
	}

	public void GameFail()
	{
		gamePanel.Lives--;
		gamePanel.DestroyMinigame(quad);
	}

	public void GameSuccess(bool perfect)
	{
		//Add Score
		Debug.Log("Minigame Success");
		gamePanel.DestroyMinigame(quad);
	}

}