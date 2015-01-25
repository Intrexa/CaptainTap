using UnityEngine;
using System.Collections;

public class BRInstrument {
	public BRInstrument(string n) {
		name = n;
		path = "Sound/" + name + "/";
		Whole = new BRInstrumentNote (16, path + "Whole");
		Half = new BRInstrumentNote (8, path + "Half");
		Quarter = new BRInstrumentNote (4, path + "Quarter");
		Eighth = new BRInstrumentNote (2, path + "Eighth");
	}
	
	public string name;
	public string path;

	public BRInstrumentNote Whole;
	public BRInstrumentNote Half;
	public BRInstrumentNote Quarter;
	public BRInstrumentNote Eighth;

	public AudioClip getInst(int duration, bool isPerfect) {
		Debug.Log (path + " " + duration.ToString() + " " + isPerfect.ToString());
		AudioClip c;
		if (isPerfect) {
			c = new BRInstrumentNote(duration, path).good;
		}
		else {
			c = new BRInstrumentNote(duration, path).bad;
		}
		return c;
	}
}

public class BRInstrumentNote {

	public BRInstrumentNote(int d, string path) {
		duration = d;
		path += displayName();
		good = Resources.Load (path + "Good") as AudioClip;
		bad = Resources.Load (path + "Bad") as AudioClip;
<<<<<<< HEAD
		miss = Resources.Load ("Sound/Miss/" + displayName () + "Miss") as AudioClip;
=======
>>>>>>> 1a407a715ee38ec23058b8e1df6f6aec0621fe5b
	}

	public int duration;
	public AudioClip good;
	public AudioClip bad;
<<<<<<< HEAD
	public AudioClip miss;
=======
>>>>>>> 1a407a715ee38ec23058b8e1df6f6aec0621fe5b

	public string displayName() {
		switch (duration) {
			case 2:
<<<<<<< HEAD
				return "Eighth";
=======
				return "Eigth";
>>>>>>> 1a407a715ee38ec23058b8e1df6f6aec0621fe5b
				break;
			case 4:
				return "Quarter";
				break;
			case 8:
				return "Half";
				break;
			case 16:
				return "Whole";
				break;
		}
		return null;
	}
}

public class SoundLibrary : MonoBehaviour {

	public string[] instrument_names = new string[11] {"ChipRecital",
			"Cooky", "Electric", "Engine", "FutureShock", "LaxClang",
		"Melee", "MetalSynth", "TechJungle", "Warp Drive", "Xtra"};

	public BRInstrument[] instruments;


	// Use this for initialization
	void Start () {
		int index = instrument_names.Length;
		instruments = new BRInstrument[index];
		for (int i=0; i<instrument_names.Length; i++) {
			instruments[i] = new BRInstrument(instrument_names[i]);
		}
	}

	public AudioClip getNote(int duration, bool isPerfect) {
		AudioClip c = null;
		while (c == null) {
			c = randomInstrument ().getInst (duration, isPerfect);
		}
		return c;
	}

	public BRInstrument randomInstrument() {
		int index = UnityEngine.Random.Range (0, instruments.Length - 1);
		return instruments [index];
	}

	public AudioClip badNote(int duration) {
<<<<<<< HEAD
		BRInstrumentNote newNote = new BRInstrumentNote (duration, "Sound/Miss/");
		return newNote.miss;
=======
		return getNote(duration, false);
>>>>>>> 1a407a715ee38ec23058b8e1df6f6aec0621fe5b
	}

	// Update is called once per frame
	void Update () {
	
	}
}
