using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {
	public float gravity = -9;
	public float speed;
	public int fallRate = 10;
	public bool onSolid = false;
	public PlayerMovement playerMovement;
	public GameObject player;
	public int zcount = 50;
	public int jumpingStage = 0;
	public float heldDownFor = 0f;
	public bool wasHeldDown = false;

	// Use this for initialization
	void Start () {
		onSolid = false;
		speed = 5;
	}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.position = new Vector3(player.transform.position.x,player.transform.position.y,-10);
		/*
		if (zcount == 0) {
			this.gameObject.transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z - 10);
			zcount = 1000;
		}
		gravity = playerMovement.gravity;
		onSolid = playerMovement.onSolid;
		transform.Translate (Vector3.up * gravity * Time.deltaTime);
		if (gravity < -9) {
			gravity = gravity - fallRate * Time.deltaTime;
		}
		if ((Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) && (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow))) {}
		else if ((Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) && !playerMovement.cantMoveLeft) {
			transform.Translate (Vector3.left * speed * Time.deltaTime);
		}
		else if ((Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) && !playerMovement.cantMoveRight) {
			transform.Translate (Vector3.right * speed * Time.deltaTime);
		}
		zcount--;

		if (((Input.GetKey (KeyCode.Space) || Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) && onSolid)) {
			jumpingStage = 1;
			if (wasHeldDown && heldDownFor <= 16.0f) {
				heldDownFor += 1.0f;
				//renderer.color = Color.Lerp(notCharged, charged, floatheld/18);
			}
			wasHeldDown = true;
		} else if (wasHeldDown) {
			wasHeldDown = false;
		} else {
			heldDownFor = 0f;
		}
		if (jumpingStage > 10) {
			jumpingStage = 0;
			
		} else if (jumpingStage == 2) {
			gravity = 5f+heldDownFor/4f;
			onSolid = false;
		}
		if (jumpingStage > 0) {
			jumpingStage++;
		}
		*/
	}
}

