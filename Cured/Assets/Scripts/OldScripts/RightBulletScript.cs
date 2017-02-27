using UnityEngine;
using System.Collections;

public class RightBulletScript : MonoBehaviour {
	public int speed;
	public int timer;
	public DeathSenser deathSenser;

	// Use this for initialization
	void Start () {
		deathSenser = GameObject.FindWithTag("Senser").GetComponent ("DeathSenser") as DeathSenser;
		speed = 5;
		timer = 600;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * speed * Time.deltaTime);
		if (timer < 0 || deathSenser.isDead) {
			Destroy (this.gameObject);
		}
		timer--;
	}
}
