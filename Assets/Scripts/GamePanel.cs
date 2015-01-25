using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GamePanel : MonoBehaviour {

	public Minigame[] minigameArray;
	public GameObject[] tempMiniGameList;
	public float panelZDistance;

	public float spawnDistance;
	public float speed;
	public float goodThreshold = 0.5f;
	public float perfectThreshold = 0.2f;

<<<<<<< HEAD
	public Material[] borderTextures;
	[SerializeField]
	private Sprite[] livesSprites;
	private Text scoreLabel; 
	[SerializeField]
	private int lives = 3;
	public MusicScore music_score;

=======
	public MusicScore music_score;

	private int lives;
>>>>>>> 1a407a715ee38ec23058b8e1df6f6aec0621fe5b
	public int Lives
    {
        get
        {
            return lives;
        }
        set
        {
            lives = value;

    	    switch (lives) {
        	case 2: transform.FindChild("Canvas").FindChild("Life3").GetComponent<Image>().sprite = livesSprites[1];
        			break;
        	case 1: transform.FindChild("Canvas").FindChild("Life2").GetComponent<Image>().sprite = livesSprites[1];
        			break;
        	case 0: transform.FindChild("Canvas").FindChild("Life1").GetComponent<Image>().sprite = livesSprites[1];
					break;
        	}

            if(lives <= 0)
            	GameFail();
        }
    }

    private int score = 0;
	public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            scoreLabel.text = "Score: " + score;
        }
    }

	private Vector3[] miniGamePositions;
	public bool started;

	// Use this for initialization
	void Start () {

<<<<<<< HEAD
		scoreLabel = transform.FindChild("Canvas").FindChild("Score").GetComponent<Text>() as Text;
=======
>>>>>>> 1a407a715ee38ec23058b8e1df6f6aec0621fe5b
		music_score = GetComponent<MusicScore> ();

		//Find Centre points of Quadrants;
		miniGamePositions = new Vector3[4];
		miniGamePositions[0] = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width*0.25f), (Screen.height*0.25f), Camera.main.nearClipPlane+panelZDistance));//new Vector3((Screen.width*0.25f),transform.y,(Screen.height*0.25f));
		miniGamePositions[1] = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width*0.25f)*3, (Screen.height*0.25f), Camera.main.nearClipPlane+panelZDistance));//new Vector3((Screen.width*0.25f),transform.y,(Screen.height*0.25f));
		miniGamePositions[2] = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width*0.25f)*3, (Screen.height*0.25f)*3, Camera.main.nearClipPlane+panelZDistance));//new Vector3((Screen.width*0.25f),transform.y,(Screen.height*0.25f));
		miniGamePositions[3] = Camera.main.ScreenToWorldPoint(new Vector3((Screen.width*0.25f), (Screen.height*0.25f)*3, Camera.main.nearClipPlane+panelZDistance));//new Vector3((Screen.width*0.25f),transform.y,(Screen.height*0.25f));

	}
	
	// Update is called once per frame
	void Update () {
		if (music_score.initialized && !started) {
			started = true;
			minigameArray = new Minigame[4];
			for(int i = 0; i < 4; i++){
				createMinigame(i);
			}
		}
	}

	public void DestroyMinigame(int quad)
	{	
		Debug.Log("Destroying Quad " + quad);
		Destroy(minigameArray[quad].gameObject);
		createMinigame(quad);
	}

	private void createMinigame(int quad)
	{	
		GameObject gameToCreate = tempMiniGameList[Random.Range(0, tempMiniGameList.Length)];
		//GameObject newGame = //Score.GetNewMiniGame();
		GameObject newGO = Instantiate(gameToCreate, miniGamePositions[quad],gameToCreate.transform.rotation) as GameObject;
		newGO.transform.localScale =new Vector3(0.01f,0.01f,0.01f);
		newGO.transform.parent = transform;
		minigameArray[quad] = newGO.GetComponent<Minigame>() as Minigame;
		minigameArray[quad].quad = quad;
		minigameArray[quad].width = Screen.width*0.5f;
		minigameArray[quad].height = Screen.height*0.5f;
		minigameArray[quad].fullScale = 0.5f;
		NoteInstance note = music_score.nextNote ();

		minigameArray[quad].arrivalTime = note.time;//Random.Range(1, 5);	//Testing
		minigameArray [quad].duration = note.length;
	}

	private void GameFail()
	{

	}
}


