using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopdownPlayer : MonoBehaviour {
	public static Binding keys;
	public int speed;
	public Sprite[] s1; //Facing 0
	public Sprite[] s2; //Facing 45
	public Sprite[] spritegroup;
	public int spritechange;
	public int spritechangeindex;
	public Vector2 lastTransform;
	public float smoothTime = 1f;
	public Vector2 targetDistance;

	private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () {
		spritegroup=s1;
		spritechangeindex = 0;
		keys = GameObject.Find ("Binding").GetComponent<Binding> ();
		speed = 3;
	}
	
	// Update is called once per frame
	void Update () {
		bool moved = true;
		//if (Input.GetKey (keys.up) && Input.GetKey (keys.down) || !(Input.GetKey (keys.up) && Input.GetKey (keys.down))) {
		if (!(Input.GetKey (keys.up) ^ Input.GetKey (keys.down))) {
			if ((Input.GetKey (keys.left) && Input.GetKey (keys.right)) || !(Input.GetKey (keys.left) || Input.GetKey (keys.right))) { // No Movement
				moved=false;
			} else if (Input.GetKey (keys.left)) { // Left
				spritegroup= s1;
				this.transform.eulerAngles = new Vector3(180, 0, 180);
			} else if (Input.GetKey (keys.right)) { // Right
				spritegroup= s1;
				this.transform.eulerAngles = new Vector3(0, 0, 0);
			}
		} else if (Input.GetKey (keys.up)) {
			if ((Input.GetKey (keys.left) && Input.GetKey (keys.right)) || !(Input.GetKey (keys.left) || Input.GetKey (keys.right))) { // Up
				spritegroup= s1;
				this.transform.eulerAngles = new Vector3(0, 0, 90);
			} else if (Input.GetKey (keys.left)) { // Up Left
				spritegroup= s2;
				this.transform.eulerAngles = new Vector3(180, 0, 180);
			} else if (Input.GetKey (keys.right)) { // Up Right
				spritegroup= s2;
				this.transform.eulerAngles = new Vector3(0, 0, 0);
			}
		} else if (Input.GetKey (keys.down)) {
			if ((Input.GetKey (keys.left) && Input.GetKey (keys.right)) || !(Input.GetKey (keys.left) || Input.GetKey (keys.right))) { // Down
				spritegroup= s1;
				this.transform.eulerAngles = new Vector3(0, 0, 270);
			} else if (Input.GetKey (keys.left)) { // Down Left
				spritegroup= s2;
				this.transform.eulerAngles = new Vector3(180, 0, 90);
			} else if (Input.GetKey (keys.right)) { // Down Right
				spritegroup= s2;
				this.transform.eulerAngles = new Vector3(0, 0, 270);
			}
		}
		if (moved) {spritechangeindex++;}
		if (spritechangeindex/spritechange>=spritegroup.Length) {spritechangeindex = 0;}
		/*
		if (spritechangeindex == spritechange) {
			spriteindex++;
			spritechangeindex = 0;
		}

		spriteindex = spriteindex+0 % spritegroup.Length;

		this.gameObject.GetComponent<SpriteRenderer> ().sprite = spritegroup [spriteindex];
		*/

		this.gameObject.GetComponent<SpriteRenderer> ().sprite = spritegroup [spritechangeindex/spritechange];
		Vector2 totalTransform = new Vector2 ();

		if (Input.GetKey (keys.left)) {
			totalTransform += Vector2.left * speed;
		} if (Input.GetKey (keys.right)) {
			totalTransform += Vector2.right * speed;
		} if (Input.GetKey (keys.up)) {
			totalTransform += Vector2.up * speed;
		} if (Input.GetKey (keys.down)) {
			totalTransform += Vector2.down * speed;
		}
	
		bool done = false;
		GameObject[] boundries = GameObject.FindGameObjectsWithTag ("Boundry");
		Vector2 movement = new Vector2 ();
		/*
		for (int i = 0; i <= 100; i++) {
			foreach (GameObject g in boundries) {
				while (this.GetComponent<BoxCollider2D> ().IsTouching (g.GetComponent<BoxCollider2D> ())) {
					done = true;
					this.GetComponent<BoxCollider2D> ().offset -= totalTransform * -0.01f;
					movement -= totalTransform * 0.01f;
				}
			}
			if (done) {break;}
			this.GetComponent<BoxCollider2D> ().offset += totalTransform / 100f;
			movement += totalTransform * 0.01f;
		}
		this.GetComponent<BoxCollider2D> ().offset = new Vector2 (0, 0);
		this.transform.Translate (movement-(totalTransform*-0.1f), Space.World);
		*/
		lastTransform = totalTransform;
		this.GetComponent<Rigidbody2D> ().velocity=totalTransform;
		/*
		transform.position += (Vector3)totalTransform;
		targetDistance+=totalTransform;
		this.transform.position = Vector3.SmoothDamp (transform.position, targetDistance, ref velocity, smoothTime);
		*/
	}

	void OnCollisionStay2D (Collision2D other) {
		if (other.gameObject.CompareTag("Boundry")) {
			
		}
	}
	/*

	Vector3 Average (Vector3 v1, Vector3 v2) {
		return new Vector3 ((v1.x + v2.x) / 2.0, (v1.y + v2.y) / 2.0, (v1.z + v2.z) / 2.0);
	}*/
}
