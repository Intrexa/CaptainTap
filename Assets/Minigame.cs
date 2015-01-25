using UnityEngine;
using System.Collections;
public class Minigame : MonoBehaviour {
	public int quad;
	public float width, height;
	public Transform foreground, background;
	public float arrivalTime;

	public float fullScale;

	public GameObject hintObject;

	public bool isDone;

	//Can't be Texture, you need create an Object and later convert in Texture
	private Object[] hintTexture;
	 
	//Change this for speed
	public int framesPerSecond = 30;
	private HintSource hintSource = null;
	private float hintDisplayCounter;
	private int[] rhythm;
	private float totalTime;
	private Vector3 startPosition;
	public GamePanel gamePanel;
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
			background.localPosition = new Vector3(background.localPosition.x,background.localPosition.y,500);

		GenerateHints();

		transform.FindChild("Border").renderer.material = gamePanel.borderTextures[quad];
	}


	public void GenerateHints()
	{
		foreach (Transform child in transform)
		{
			hintSource = child.GetComponent<HintSource>() as HintSource;
			if(hintSource)
			{
				hintObject.SetActive(false);
				break;
			}
		}
		if(hintSource)
		{
			hintObject.transform.localPosition = hintSource.transform.localPosition;
			hintObject.transform.localScale *= 0.75f; 
			//Load Hint
			switch (hintSource.hintType)
			{
				case HintType.Circle: 		hintTexture = Resources.LoadAll("Hints/Circle");
											break;
				case HintType.UpArrow: 		hintTexture = Resources.LoadAll("Hints/UpArrow");
											hintObject.transform.localPosition += new Vector3(0.4f,2,0);
											break;
				case HintType.DownArrow:	hintTexture = Resources.LoadAll("Hints/UpArrow");
											hintObject.transform.localRotation = Quaternion.Euler(new Vector3(0,0,180));
											hintObject.transform.localPosition += new Vector3(-0.30f,-2,0);
											break;
				case HintType.RightArrow: 	hintTexture = Resources.LoadAll("Hints/RightArrow");
											hintObject.transform.localPosition += new Vector3(2,0,0);
											break;
				case HintType.LeftArrow: 	hintTexture = Resources.LoadAll("Hints/RightArrow");
											hintObject.transform.localRotation = Quaternion.Euler(new Vector3(0,0,180));
											hintObject.transform.localPosition += new Vector3(-2,0.25f,0);
											break;
			}	
		}	
	}
	

	// Update is called once per frame
	void Update () {

		float timeLeft = arrivalTime - Time.time;

		if(hintSource && timeLeft <= 0)
		{	
			if(hintDisplayCounter <= 0)
				hintDisplayCounter = Time.time;
			hintObject.SetActive(true);
			int index = (int) Mathf.Repeat((((Time.time)-hintDisplayCounter) * hintTexture.Length/2.0f), hintTexture.Length);
		    //Animate Sprite
		    hintObject.renderer.material.mainTexture = hintTexture[index] as Texture; 
		    if(hintSource.moving)
		    	hintObject.transform.localPosition = hintSource.transform.localPosition;
		}



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

	public void GameDestroy()
	{
		gamePanel.DestroyMinigame(quad);
	}

	public void GameSuccess(bool perfect)
	{
		//Add Score
		if(perfect)
			gamePanel.Score += 20;
		else
			gamePanel.Score += 10;
		
	}



}