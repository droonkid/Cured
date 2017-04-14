using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour {
	public GameObject followee;
	public Vector3 followeestart;
	public bool gotToStart = false;
	public Vector3 followeelast;
	public Vector3 lasttransform;
	public int spritechangeindex;
	public int spritechange;
	public Sprite[] sg1;
	public Sprite[] sg2;
	public Sprite[] spritegroup;

	private Vector3 velocity = Vector3.zero;
	// Use this for initialization
	void Start () {
		spritegroup = sg1;
		lasttransform = transform.position;
		followeestart = followee.transform.position;
		followeelast = followee.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (gotToStart) {
			transform.position = (Vector3)followee.GetComponent<TopdownPlayer> ().lastpositions.GetValue (0);
		} else {
			if (!(followeelast == followee.transform.position)) {
				transform.Translate(Vector3.up * followee.GetComponent<TopdownPlayer> ().speed * Time.deltaTime, Space.World);
			}
		}

		if (transform.position.y >= followeestart.y) {
			gotToStart = true;
		}

		Vector3 change = transform.position - lasttransform;
		bool moved = true;
		if (change.y == 0) {
			if (change.x == 0) { // No Movement
				moved = false;
			} else if (change.x > 0) { // Right
				spritegroup = sg1;
				this.transform.eulerAngles = new Vector3 (0, 0, 0);
			} else if (change.x < 0) { // Left
				spritegroup = sg1;
				this.transform.eulerAngles = new Vector3 (180, 0, 180);
			}
		} else if (change.y > 0) {
			if (change.x == 0) { // Up
				spritegroup = sg1;
				this.transform.eulerAngles = new Vector3 (0, 0, 90);
			} else if (change.x > 0) { // Up Right
				spritegroup = sg2;
				this.transform.eulerAngles = new Vector3 (0, 0, 0);
			} else if (change.x < 0) { // Up Left
				spritegroup = sg2;
				this.transform.eulerAngles = new Vector3 (180, 0, 180);
			}
		} else if (change.y < 0) { 
			if (change.x == 0) { // Down
				spritegroup = sg1;
				this.transform.eulerAngles = new Vector3 (0, 0, 270);
			} else if (change.x > 0) { // Down Right
				spritegroup = sg2;
				this.transform.eulerAngles = new Vector3 (0, 0, 270);
			} else if (change.x < 0) { // Down Left
				spritegroup = sg2;
				this.transform.eulerAngles = new Vector3 (180, 0, 90);
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

		lasttransform = transform.position;
		followeelast = followee.transform.position;
	}
}
