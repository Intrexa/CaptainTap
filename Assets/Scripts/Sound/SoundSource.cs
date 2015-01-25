using UnityEngine;
using System.Collections;

public class SoundSource : MonoBehaviour {

	public AudioClip clip;
	public string name;
	public AudioSource source;
	public float start_time;

	void Start() {
		source = GetComponent<AudioSource> ();
	}

	// Use this for initialization
	public void initialize (string n, AudioClip c, bool loop, float time) {
		name = n;
		clip = c;
		source.clip = clip;
		source.loop = loop;
		source.playOnAwake = false;
		source.PlayScheduled (time);
		start_time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if (start_time != 0f) {
			if (Time.time - start_time > source.clip.length) {
				Destroy (gameObject);
			}
		}
	}
}
