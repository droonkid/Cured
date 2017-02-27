using UnityEngine;
using System.Collections;

public class LeftBulletScript : MonoBehaviour {
	public int speed;
	public int timer;

	// Use this for initialization
	void Start () {
		speed = 5;
		timer = 600;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * speed * Time.deltaTime);
		if (timer < 0) {
			Destroy (this.gameObject);
		}
		timer--;
	}
}
