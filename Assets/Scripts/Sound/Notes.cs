using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


[System.Serializable]
public class Measure{
	public int[] notes = new int[16];
	public List<NoteConf> notesAvailable;
	public int index = 0;
	
	public void init(List<NoteConf> notesAvail) {
		notesAvailable = notesAvail;
		addBeat ();
		bool looping = true; 
		while (looping) {
			looping = false;
			if (index < 16) {
				for (int i = 0; i < notesAvailable.Count; i++) {
					if (notesAvailable[i].canStillPlace(index)) {
						addBeat ();
						looping = true;
						break;
					}
				}
			}
		}
		display ();
	}
	
	public void display() {
		
		string disp = "";
		for (int i=0; i<notes.Length; i++) {
			disp += notes[i].ToString () + " ";
		}
		Debug.Log (disp);
	}
	
	void addBeat() {
		NoteConf newNote = new NoteConf();
		List<NoteConf> notesAllowed = new List<NoteConf> ();
		if (index == 0) {
			notesAllowed = notesAvailable.Where (n => n.length > 1).ToList ();
		} else {
			notesAllowed = notesAvailable;
		}
		
		notesAllowed = notesAllowed.Where (n => n.length <= 16 - index).ToList ();
		if (notesAllowed.Count > 0) {
			List<NoteConf> weightedNotes = new List<NoteConf>();
			for (int i = 0; i < notesAllowed.Count; i++) {
				for (int j = 1; j <= i+1; j++) {
					weightedNotes.Add (notesAllowed[i]);
				}
			}
			int noteIndex = UnityEngine.Random.Range (0, weightedNotes.Count);
			newNote.length = weightedNotes [noteIndex].length;
			newNote.syncopated_allowed = weightedNotes[noteIndex].syncopated_allowed;
			
			List<int> locs = newNote.allowed_locations ().Where (loc => loc >= index).ToList ();
			int timeIndex = locs [UnityEngine.Random.Range (0, Math.Min (3, locs.Count - 1))];
			notes [timeIndex] = newNote.length;
			index = timeIndex + newNote.length;
		} else {
			index = 15;
		}
		
	}
	
}

[System.Serializable]
public class NoteConf{
	public int length;
	public bool syncopated_allowed;
	
	public List<int> allowed_locations() {
		Debug.Log ("allowed locations");
		List<int> locs = new List<int> ();
		for (int i=0; i<= 16-length; i+=length) {
			locs.Add (i);
		}
		if (syncopated_allowed) {
			if (length > 1) {
				
				for (int i=length/2; i<=16-(3*length/2); i+=length/2) {
					locs.Add (i);
				}
				
			}
		}
		return locs;
	}
	
	public bool canStillPlace(int index) {
		List<int> locs = allowed_locations ();
		for (int i=0; i<locs.Count(); i++) {
			if (locs[i] >= index)
				return true;
		}
		return false;
		
	}
	
}

public class Notes : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
