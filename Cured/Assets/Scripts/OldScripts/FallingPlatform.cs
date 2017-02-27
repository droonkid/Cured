using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour {
	public PlayerMovement player;
	public bool isGravity;
	public float gravity = -2;
	public int fallRate = 9;
	public int timer = 50;
	public bool isTimer;
	public GameObject PlatformRespawn;

	// Use this for initialization
	void Start () {
		transform.position = PlatformRespawn.transform.position;
		this.gameObject.tag = "Solid";
		isGravity = false;
		isTimer = false;
		timer = 50;
		gravity =-2;
	}
	
	// Update is called once per frame
	void Update () {
		if (isGravity) {
			gravity -= fallRate * Time.deltaTime;
			this.gameObject.transform.Translate (Vector3.up * gravity * Time.deltaTime);
			if (gravity < -2) {
				gravity = gravity - fallRate * Time.deltaTime;
			}
		}
		if (isTimer) {
			timer -= 1;
		}
		if (timer == 0) {
			this.gameObject.tag = "Fall";
			this.gameObject.transform.Translate (Vector3.down * 1 * 0.1f);
			if (player.transform.position.y>transform.position.y) {
				player.onSolid = false;
			}
			this.gameObject.transform.Translate (Vector3.up * 1.2f * 0.1f);
			isGravity = true;
		}
		if (timer == -100) {
			timer = 0;
			Start ();
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Player")) {
			isTimer = true;
		}
	}
}

