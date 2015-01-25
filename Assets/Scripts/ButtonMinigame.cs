using UnityEngine;
using System.Collections;

public class ButtonMinigame : MonoBehaviour {

	public Minigame minigame;
	public float lerpTime;

	void Start()
	{
		minigame = transform.parent.GetComponent<Minigame>();
	}

	void Update()
	{
		
	}

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

	void Tapped()
	{
		minigame.GameSuccess(true);
		minigame.GameDestroy();
	}
}
