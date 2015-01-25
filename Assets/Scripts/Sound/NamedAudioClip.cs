using UnityEngine;
using System.Collections;

[System.Serializable]
public class NamedAudioClip : MonoBehaviour {

	public NamedAudioClip(string n, AudioClip c) {
		name = n;
		clip = c;
	}

	public string name;
	public AudioClip clip;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
