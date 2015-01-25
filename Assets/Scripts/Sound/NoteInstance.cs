using UnityEngine;
using System.Collections;

[System.Serializable]
public class NoteInstance{

	public NoteInstance(int l, float t)  {
		length = l;
		time = t;
	}

	public int length;
	public float time;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
