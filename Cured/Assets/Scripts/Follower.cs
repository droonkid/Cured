using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour {
	public GameObject followee = GameObject.FindGameObjectWithTag("Player");

	private Vector3 velocity = Vector3.zero;
	// Use this for initialization
	void Start () {
		this.transform.position = Vector3.SmoothDamp (this.transform.position, followee.transform.position, ref velocity, 0.2f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Mathf.Pow(transform.position.x-followee.transform.position.x, 2)+Mathf.Pow(transform.position.y-followee.transform.position.y, 2)>16) {
			this.transform.position = Vector3.SmoothDamp (this.transform.position, followee.transform.position, ref velocity, 1.5f);
		}
	}
}
