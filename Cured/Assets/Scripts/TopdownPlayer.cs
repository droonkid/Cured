using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopdownPlayer : MonoBehaviour {
	public static Binding keys;
	public int speed;
	public Sprite s1; //Facing 0
	public Sprite s2; //Facing 45


	// Use this for initialization
	void Start () {
		keys = GameObject.Find ("Binding").GetComponent<Binding> ();
		speed = 3;
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.GetKey (keys.up) && Input.GetKey (keys.down) || !(Input.GetKey (keys.up) && Input.GetKey (keys.down))) {
		if (!(Input.GetKey (keys.up) ^ Input.GetKey (keys.down))) {
			if ((Input.GetKey (keys.left) && Input.GetKey (keys.right)) || !(Input.GetKey (keys.left) || Input.GetKey (keys.right))) { // No Movement
				
			} else if (Input.GetKey (keys.left)) { // Left
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = s1;
				this.transform.eulerAngles = new Vector3(180, 0, 180);
			} else if (Input.GetKey (keys.right)) { // Right
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = s1;
				this.transform.eulerAngles = new Vector3(0, 0, 0);
			}
		} else if (Input.GetKey (keys.up)) {
			if ((Input.GetKey (keys.left) && Input.GetKey (keys.right)) || !(Input.GetKey (keys.left) || Input.GetKey (keys.right))) { // Up
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = s1;
				this.transform.eulerAngles = new Vector3(0, 0, 90);
			} else if (Input.GetKey (keys.left)) { // Up Left
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = s2;
				this.transform.eulerAngles = new Vector3(180, 0, 180);
			} else if (Input.GetKey (keys.right)) { // Up Right
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = s2;
				this.transform.eulerAngles = new Vector3(0, 0, 0);
			}
		} else if (Input.GetKey (keys.down)) {
			if ((Input.GetKey (keys.left) && Input.GetKey (keys.right)) || !(Input.GetKey (keys.left) || Input.GetKey (keys.right))) { // Down
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = s1;
				this.transform.eulerAngles = new Vector3(0, 0, 270);
			} else if (Input.GetKey (keys.left)) { // Down Left
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = s2;
				this.transform.eulerAngles = new Vector3(180, 0, 90);
			} else if (Input.GetKey (keys.right)) { // Down Right
				this.gameObject.GetComponent<SpriteRenderer> ().sprite = s2;
				this.transform.eulerAngles = new Vector3(0, 0, 270);
			}
		}

		Vector2 totalTransform = new Vector2 ();

		if (Input.GetKey (keys.left)) {
			totalTransform += Vector2.left * speed * Time.deltaTime;
		} if (Input.GetKey (keys.right)) {
			totalTransform += Vector2.right * speed * Time.deltaTime;
		} if (Input.GetKey (keys.up)) {
			totalTransform += Vector2.up * speed * Time.deltaTime;
		} if (Input.GetKey (keys.down)) {
			totalTransform += Vector2.down * speed * Time.deltaTime;
		}
		bool done = false;
		GameObject[] boundries = GameObject.FindGameObjectsWithTag ("Boundry");
		Vector2 movement = new Vector2 ();
		//this.transform.Translate(totalTransform
		for (int i = 0; i <= 100; i++) {
			/*if (this.gameObject.GetComponent<BoxCollider2D> ().IsTouchingLayers ()) {
				break;
			}*/
			foreach (GameObject g in boundries) {
				if (this.GetComponent<BoxCollider2D> ().IsTouching (g.GetComponent<BoxCollider2D> ())) {
					done = true;
					//this.transform.Translate (totalTransform * -0.02f, Space.World);
					break;
				}
			}
			if (done) {break;}
			this.GetComponent<BoxCollider2D> ().offset += totalTransform / 100;
			movement += totalTransform / 100;
		}
		this.GetComponent<BoxCollider2D> ().offset = new Vector2 (0, 0);
		this.transform.Translate (movement, Space.World);
	}

	/*

	Vector3 Average (Vector3 v1, Vector3 v2) {
		return new Vector3 ((v1.x + v2.x) / 2.0, (v1.y + v2.y) / 2.0, (v1.z + v2.z) / 2.0);
	}*/
}
