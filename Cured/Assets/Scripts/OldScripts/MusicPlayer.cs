using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	public new AudioSource audio;
	public AudioClip mainMusic1;
	public AudioClip mainMusic2;
	public AudioClip mainMusic3;
	public AudioClip amalgam;
	public AudioClip sugalite;
	public AudioClip enticement;
	public bool muted = true;

	// Use this for initialization
	void Start () {
		int random = Random.Range (1, 8);
		switch (random) {
			case 1:
				audio.PlayOneShot (mainMusic1);
				break;
			case 2:
				audio.PlayOneShot (mainMusic2);
				break;
			case 3:
				audio.PlayOneShot (mainMusic3);
				break;
			case 4:
				audio.PlayOneShot (amalgam);
				break;
			case 5:
				audio.PlayOneShot (sugalite);
				break;
			case 6:
				audio.PlayOneShot (enticement);
				break;
			case 7:
				audio.PlayOneShot (mainMusic3);
				break;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void button () {
		audio.Stop ();
		Start ();
	}

	public void mute () {
		if (muted) {
			Start ();
		} else {
			audio.Stop ();
		}
	}
}
