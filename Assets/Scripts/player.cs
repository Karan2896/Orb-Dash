using UnityEngine;
using System.Collections;

using UnityEngine.EventSystems;

public class player : MonoBehaviour {

	Rigidbody2D rb;
	public float speed = 3F;
	public static int score;
	public static bool gameOver;
	public audioManager am;
	float timer = 4f;
	public static bool bluecheck,yellowcheck;
	float tempSpeed;
	public GameObject cam;

	void Start () {
		bluecheck =yellowcheck= false;
		gameOver = false;
		rb = GetComponent<Rigidbody2D> ();
		score = 0;
	}
	

	void Update ()
	{
		if (bluecheck==true) {
			timer -= Time.deltaTime;
			if (timer < 0) {
				Pug.speed = tempSpeed;
				bluecheck = false;
				timer = 4f;
			}

		}
		else if (yellowcheck==true) {
			timer -= Time.deltaTime;
			if (timer < 0) {
				yellowcheck = false;
				timer = 4f;
			}

		}
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			
			Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
			rb.AddForce (touchDeltaPosition * speed);
		}

	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "arenaboundary") {
			
			rb.velocity = Vector3.zero;
		}
		if (other.gameObject.tag == "greenpug") {
			score++;
			am.playerHit.Play ();
			Destroy (other.gameObject);
			shooter.pugCount--;
			shooter.greencount--;
			shooter.check = true;
		} else if (other.gameObject.tag == "redpug") {
			if (yellowcheck == true) {
				Physics2D.IgnoreCollision (other.gameObject.GetComponent<Collider2D> (), GetComponent<Collider2D> ());
			} else {
				cam.GetComponent<CameraShake> ().enabled = true;
				gameOver = true;
				uiManager2.survivalmode = false;
				gameObject.SetActive (false);
			}
		} else if (other.gameObject.tag == "bluepug") {
			bluecheck = true;
			Destroy (other.gameObject);
			tempSpeed = Pug.speed;
			Pug.speed = 1f;
		}
		else if (other.gameObject.tag == "yellowpug") {
			yellowcheck = true;
			Destroy (other.gameObject);

		}
   }
}
