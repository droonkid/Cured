using UnityEngine;
using System.Collections;

public class ButtonPlacement : MonoBehaviour {

	public GameObject button;

	// Use this for initialization
	void Start () {
	
	}

	void Update () {

	}

	// Update is called once per frame
	void OnGUI(){
		//GUI.Box (new Rect (0,0,100,50), "Top-left");
		//button.transform.position = new Vector3 (Screen.width - 80, Screen.width - 15, 0);
		//GUI.Box (new Rect (Screen.width - 160,0,160,30), "Play New Track");
		//GUI.Box (new Rect (0,Screen.height - 50,100,50), "Bottom-left");
		//GUI.Box (new Rect (Screen.width - 100,Screen.height - 50,100,50), "Bottom-right");
	}
}
