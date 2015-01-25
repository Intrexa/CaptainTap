using UnityEngine;
using System.Collections;

[System.Serializable]
public class RhythmicPattern : MonoBehaviour {

	public RhythmicPattern(int[] n) {
		notes = n;
	}
	public int[] notes = new int[16];
	public int addIndex = 0;

	// Use this for initialization
	void Start () {
	
	}

	public void addNote(int len) {
		if ((16-addIndex) >= len) {
			notes[addIndex] = len;
			addIndex += len;
		}
	}

	public void addRest(int len) {
		for (int i=0; i<len; i++) {
			notes[addIndex] = 0;
			addIndex += 1;
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
