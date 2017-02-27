using UnityEngine;
using System.Collections;

public class DeathSenser : MonoBehaviour {

	public bool Dead = false;
	public bool isDead = false;
	public int count = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		count--;
		if (count > 0) {
			isDead = true;
		} else {
			isDead = false;
		}
		if (Dead) {
			count = 10;
			Dead = false;
		}
	}
}
