using UnityEngine;
using UnityEditor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


//[ExecuteInEditMode]
[System.Serializable]
public class MusicScore : MonoBehaviour {
	public List<int> theScore;
	public List<NoteConf> notesAvailable;
	public int turns = 0;
	public bool initialized = false;

	public int complexity;
	public float beatLen = 3/16f;
	public int beatIndex = 0;
	public int currentAssignIndex = 0;

	public AudioClip[] bgMusic;

	public List<int[]> Comp_1_Patterns;
	public List<int[]> Comp_2_Patterns;
	public List<int[]> Comp_3_Patterns;

	public TextAsset csv;

	public bool activate;


	// Use this for initialization
	void Start () {

		initialized = false;

		beatLen = 3/16f;

		theScore = new List<int> ();
		//activate = true;

		string[,] conf = CSVReader.SplitCsvGrid(csv.text);
		Comp_1_Patterns = new List<int[]>();
		for (int i=1; i < 6; i++) {
			Comp_1_Patterns.Add(IntArrayFromTextRow(conf, i));
		}
		
		Comp_2_Patterns = new List<int[]>();
		for (int i=7; i < 16; i++) {
			Comp_2_Patterns.Add(IntArrayFromTextRow(conf, i));
		}
		
		Comp_3_Patterns = new List<int[]>();
		for (int i=17; i < 27; i++) {
			Comp_3_Patterns.Add(IntArrayFromTextRow(conf, i));
		}
		string disp = "";
		for (int i=0; i<16; i++) {
			disp += Comp_3_Patterns[5][i].ToString () + " ";
		}
		Debug.Log (disp);
		Debug.Log (Comp_1_Patterns);
		Debug.Log (Comp_2_Patterns);
		Debug.Log (Comp_3_Patterns);
		EditorUtility.SetDirty(transform);
		CSVReader.DebugOutputGrid(CSVReader.SplitCsvGrid(csv.text));

		addPhrase();

		initialized = true;

	}

	public float beatTime(int index) {
		return index * beatLen;
	}

	public int[] IntArrayFromTextRow (string[, ] array, int row){
		int[] intArray = new int[16];
		for (int i=0; i<16; i++) {
			intArray[i] = Int32.Parse (array[i, row]);
		}
		return intArray;
	}

	public void addPhrase() {
		List<int[]> patternSet;
		if (beatIndex < 16*6) {
			patternSet = Comp_1_Patterns;
		}
		else if (beatIndex < 16*12) {
			patternSet = Comp_2_Patterns;
		}
		else {
			patternSet = Comp_3_Patterns;
		}
		Debug.Log (patternSet);
		Debug.Log (Comp_1_Patterns);
		theScore.AddRange (patternSet [UnityEngine.Random.Range (0, patternSet.Count() - 1)]);
	}

	// Update is called once per frame
	void Update () {
		if (initialized) {

			int beatDiff = 1;
			AudioSource audio = gameObject.GetComponent<AudioSource> ();
			if (beatIndex == 0) {
				newBGMusic(0, false, beatTime (0));
				//StartCoroutine("addMeasure");
				beatIndex = 1;
			}
			else if (Time.time > beatTime (beatIndex + beatDiff)) {
				beatIndex += beatDiff;
				if (beatIndex == (16*6*3)) {
					newBGMusic (1, true, beatTime (16*6*3));
				}
				if ((beatIndex + 1) % 16 == 0) {
					addPhrase ();
				}
			}
		}
	}

	public void newBGMusic(int i, bool loop, float time) {
		AudioClip clip = bgMusic[i];
		newAudioSource(name, clip, loop, time);
	}

	public void newAudioSource(string name, AudioClip clip, bool loop, float time) {
		GameObject src_obj = GameObject.Instantiate(Resources.Load("Prefabs/Audio Source")) as GameObject;
		SoundSource src = src_obj.GetComponent<SoundSource>();
		src.initialize (name, clip, loop, time);
	}

	public NoteInstance[] nextPattern() {
		if (!initialized) {
			return null;
		}
		if (currentAssignIndex == 0) {
			currentAssignIndex = beatIndex;
		}
		NoteInstance[] pattern = new NoteInstance[1];
		return pattern;
		//return new NoteInstance (4, beatTime (currentAssignIndex));
	}

	public NoteInstance nextNote() {
		if (!initialized) {
			return null;
		}
		if (currentAssignIndex == 0) {
			currentAssignIndex = beatIndex;
		}
		while (theScore[currentAssignIndex] == 0) {
			currentAssignIndex++;
			if (currentAssignIndex == theScore.Count) {
				addPhrase ();
			}
		}
		//Debug.Log ("!!!!!!!!" + theScore [currentAssignIndex].ToString() + " !!!!! " + beatTime (currentAssignIndex));
		NoteInstance note = new NoteInstance (theScore [currentAssignIndex], beatTime (currentAssignIndex));
		currentAssignIndex++;
		return note;
	}
}