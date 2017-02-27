using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
	public float gravity = 0;
	public float speed;
	public int fallRate = 10;
	public bool onSolid = false;
	public bool facingRight;
	public new SpriteRenderer sRenderer;
	public Sprite mainCharImg;
	public Sprite paperImg;
	public Sprite jumpImg1;
	public Sprite jumpImg2;
	public Sprite moveImg;
	public int justChanged;
	public int jumpingStage;
	public GameObject player;
	public new GameObject camera;
	public GameObject respawn;
	public GameObject cameraRespawn;
	public float heldDownFor;
	public bool wasHeldDown;
	public Color charged;
	public Color notCharged;
	public int wasMove;
	public bool cantMoveLeft;
	public bool cantMoveRight;
	public GameObject enemy;
	public bool bounce = false;
	public DeathSenser deathSenser;
	public int godstage;
	public bool godmode;
	public bool godkeyheld;
	public SkinPlaceholder currSkin;

	// Use this for initialization
	void Start () {
		onSolid = false;
		speed = 5;
		facingRight = true;
		justChanged = 0;
		jumpingStage = 0;
		wasMove = 0;
		godstage = 0;
		godmode = false;
		godkeyheld = false;
	}
	
	// Update is called once per frame
	void Update () {
		/*mainCharImg = currSkin.mainCharImg;
		paperImg=currSkin.paperImg;
		jumpImg1 = currSkin.jumpImg1;
		jumpImg2 = currSkin.jumpImg2;
		moveImg = currSkin.moveImg;*/
		if (!godkeyheld) {
			if (Input.GetKey (KeyCode.UpArrow) && godstage < 2) {
				godstage += 1;
				godkeyheld = true;
			} else if (Input.GetKey (KeyCode.DownArrow) && godstage > 1 && godstage < 4) {
				godstage += 1;
				godkeyheld = true;
			} else if (Input.GetKey (KeyCode.LeftArrow) && (godstage == 4 || godstage == 6)) {
				godstage += 1;
				godkeyheld = true;
			} else if (Input.GetKey (KeyCode.RightArrow) && (godstage == 5 || godstage == 7)) {
				godstage += 1;
				godkeyheld = true;
			} else if (Input.GetKey (KeyCode.B) && godstage == 8) {
				godstage += 1;
				godkeyheld = true;
			} else if (Input.GetKey (KeyCode.A) && godstage == 9) {
				godmode = !godmode;
				godstage = 0;
			} else if (Input.anyKey) {
				godstage = 0;
			}
		} else {
			if (!Input.anyKey) {
				godkeyheld = false;
			}
		}
		if (!onSolid) {
			gravity -= fallRate * Time.deltaTime;
		} else {
			gravity = 0;
		}
		transform.Translate (Vector3.up * gravity * Time.deltaTime);
		if (gravity < -9) {
			gravity = gravity - fallRate * Time.deltaTime;
		}
		if ((Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) && (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow))) {
		} else if ((Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.LeftArrow)) && !cantMoveLeft) {
			if (facingRight) {
				transform.Rotate(new Vector3(0, 180, 0));

				sRenderer.sprite = paperImg;
				justChanged=1;
			}
			transform.Translate (Vector3.right * speed * Time.deltaTime);
			facingRight = false;
			if (onSolid && wasMove>18 && justChanged == 0) {
				sRenderer.sprite = mainCharImg;
				wasMove = 0;
			} else if (wasMove == 8 && onSolid && justChanged == 0) {
				sRenderer.sprite = moveImg;
				wasMove++;
			} else {
				wasMove++;
			}
			cantMoveRight = false;
			
		} else if ((Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.RightArrow)) && !cantMoveRight) {
			if (!facingRight) {
				transform.Rotate(new Vector3(0, 180, 0));
				sRenderer.sprite = paperImg;
				justChanged=1;
			}
			transform.Translate (Vector3.right * speed * Time.deltaTime);
			facingRight = true;
			if (onSolid && wasMove>18 && justChanged == 0) {
				sRenderer.sprite = mainCharImg;
				wasMove = 0;
			} else if (wasMove == 8 && onSolid && justChanged == 0) {
				sRenderer.sprite = moveImg;
				wasMove++;
			} else {
				wasMove++;
			}
			cantMoveLeft = false;
		}
		if (((Input.GetKey (KeyCode.Space) || Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W)) && onSolid) || bounce) {
			jumpingStage = 1;
			sRenderer.sprite = jumpImg1;
			bounce = false;
			if (wasHeldDown && heldDownFor <= 16.0f) {
				heldDownFor += 1.0f;
				//renderer.color = Color.Lerp(notCharged, charged, floatheld/18);
			}
			wasHeldDown = true;
		} else if (wasHeldDown) {
			wasHeldDown = false;
		} else {
			heldDownFor = 0f;
			sRenderer.color = notCharged;
		}
		if (justChanged>=8) {
			sRenderer.sprite = mainCharImg;
			justChanged=0;
		}
		if (justChanged>0){
			justChanged++;
		}
		if (jumpingStage > 10) {
			sRenderer.sprite = mainCharImg;
			jumpingStage = 0;

		} else if (jumpingStage == 2) {
			gravity = 5f+heldDownFor/4f;
			onSolid = false;
			sRenderer.sprite = jumpImg2;
			cantMoveLeft = false;
			cantMoveRight = false;
		}
		if (jumpingStage > 0) {
			jumpingStage++;
		}
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.CompareTag("Solid")) {
			gravity = 0;
			onSolid = true;
			cantMoveLeft = false;
			cantMoveRight = false;
		} else if (other.CompareTag ("Fall")) {
			onSolid = false;
		}
		if (other.CompareTag ("Death")) {
			if (!godmode) {
				onSolid = false;
				speed = 5;
				gravity = 0;
				player.transform.position = respawn.transform.position;
				camera.transform.position = cameraRespawn.transform.position;
				deathSenser.Dead = true;
			}
		}
		if (other.CompareTag ("Hat")) {
			Destroy (enemy);
			bounce = true;
			heldDownFor = 15f;
		}
		if (other.CompareTag ("Win")) {
			Application.LoadLevel ("YouWin");
		}
		if (other.CompareTag ("Boundry")) {
			if (facingRight) {
				cantMoveRight = true;
			} else {
				cantMoveLeft = true;
			}
		}
	}
}
