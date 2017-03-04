using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void LoadGameLevel() {
		SceneManager.LoadScene ("Game");
	}

	// Update is called once per frame
	void Update () {
	
	}
}
