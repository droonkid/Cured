using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour {
	
	public new AudioSource audio;
	public AudioClip[] songs;
	// Use this for initialization
	void Start () {
		audio = this.gameObject.GetComponent<AudioSource> ();
		PlayRandom ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!audio.isPlaying) {
			PlayRandom ();
		}
	}

	void PlaySong (int song) {
		audio.PlayOneShot (songs[song]);
	}

	void PlayRandom () {
		audio.PlayOneShot (songs [Random.Range (0, songs.Length)]);
	}
}
