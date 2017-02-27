using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopdownPlayer : MonoBehaviour {
	public Binding keys;
	public int speed;


	// Use this for initialization
	void Start () {
		keys = GameObject.Find ("Binding").GetComponent<Binding> ();
		speed = 3;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey (keys.left) && Input.GetKey (keys.right)) {
		} else if (Input.GetKey (keys.left)) {
			this.transform.eulerAngles = new Vector3(0, 180, 0);
		} else if (Input.GetKey (keys.right)) {
			this.transform.eulerAngles = new Vector3(0, 0, 0);
		}

		if (Input.GetKey (keys.left) && Input.GetKey (keys.right)) {
		} else if (Input.GetKey (keys.left)) {
			this.transform.Translate (Vector3.right * speed * Time.deltaTime);
		} else if (Input.GetKey (keys.right)) {
			this.transform.Translate (Vector3.right * speed * Time.deltaTime);
		}
		if (Input.GetKey (keys.up) && Input.GetKey (keys.down)) {
		} else if (Input.GetKey (keys.up)) {
			this.transform.Translate (Vector3.up * speed * Time.deltaTime);
		} else if (Input.GetKey (keys.down)) {
			this.transform.Translate (Vector3.down * speed * Time.deltaTime);
		}

	}
}
