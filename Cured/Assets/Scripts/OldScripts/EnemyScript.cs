using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	public GameObject player;
	public GameObject BulletSpawn;
	public GameObject RightBullet;
	public GameObject LeftBullet;
	public bool facingRight;
	public Sprite resting;
	public Sprite move;
	public Sprite ready;
	public GameObject enemy;
	public int speed;
	public SpriteRenderer enemySprite;
	public bool cantMoveLeft;
	public bool cantMoveRight;
	public int timer;
	public int wasMove;
	public DeathSenser deathSenser;
	public GameObject respawn;
	
	// Use this for initialization
	void Start () {
		transform.position = respawn.transform.position;
		facingRight = false;
		speed = 3;
		cantMoveRight = false;
		cantMoveLeft = false;
		timer = 0;
		wasMove = 0;

	}
	
	// Update is called once per frame
	void Update () {
		if (deathSenser.isDead) {
			Start ();
		}
		timer -= 1;
		float playerpos = player.transform.position.x;
		float enemypos = transform.position.x;
		if (playerpos > enemypos && playerpos < enemypos + 20f && !cantMoveRight) {
			if (wasMove<4) {
				enemySprite.sprite = move;
			} else if (wasMove<8) {
				enemySprite.sprite = ready;
				wasMove=1;
			} 
			wasMove++;
			if (!facingRight) {
				enemy.transform.Rotate (new Vector3 (0, 180, 0));
			}
			facingRight = true;
			enemy.transform.Translate (Vector3.left * speed * Time.deltaTime);
			cantMoveLeft = false;
		} else if (playerpos < enemypos && playerpos > enemypos - 20f && !cantMoveLeft) {
			if (wasMove<9) {
				enemySprite.sprite = move;
			} else if (wasMove<18) {
				enemySprite.sprite = ready;
				wasMove=0;
			} 
			wasMove++;
			if (facingRight) {
				enemy.transform.Rotate (new Vector3 (0, 180, 0));
			}
			facingRight = false;
			enemy.transform.Translate (Vector3.left * speed * Time.deltaTime);
			cantMoveRight = false;
		} else if ((playerpos < enemypos && playerpos > enemypos - 20f) || (playerpos > enemypos && playerpos < enemypos + 20f) || cantMoveRight || cantMoveLeft) {
			enemySprite.sprite = ready;
		} else {
			enemySprite.sprite = resting;
		}
		if (((cantMoveLeft || cantMoveRight || (playerpos < enemypos && playerpos > enemypos - 15f) || (playerpos > enemypos && playerpos < enemypos + 15f)) && timer<0)) {
			Fire ();
			timer = 70;
		}
	}

	void OnTriggerEnter (Collider other) {
		if (other.CompareTag ("Boundry")) {
			if (facingRight) {
				cantMoveRight = true;
			}
			else {
				cantMoveLeft = true;
			}
		}
	}

	void Fire() {
		if (facingRight) {
			Instantiate (RightBullet, BulletSpawn.transform.position, Quaternion.identity);
		} else {
			Instantiate (LeftBullet, BulletSpawn.transform.position, Quaternion.identity);
		}
	}
}
