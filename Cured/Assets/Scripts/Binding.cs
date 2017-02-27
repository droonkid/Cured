using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Binding : MonoBehaviour {
	public KeyCode up;
	public KeyCode down;
	public KeyCode left;
	public KeyCode right;


	// Use this for initialization
	void Start () {
		up = KeyCode.W;
		down = KeyCode.S;
		left = KeyCode.A;
		right = KeyCode.D;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
