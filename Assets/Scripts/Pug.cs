using UnityEngine;
using System.Collections;

public class Pug : MonoBehaviour {

	public static float speed = 0.2f;
	ParticleSystem ps;
	audioManager am;
	int arenaHit;

	void Start () {
		ps = GetComponent<ParticleSystem> ();
		am = FindObjectOfType<audioManager> ();
		arenaHit = 0;
	}
	

	void Update () {
		transform.Translate (Vector3.right*Time.deltaTime*speed);
		Debug.DrawLine (transform.position, transform.position + transform.right, Color.green);

		if (uiManager2.difficultymode == 1 || uiManager2.difficultymode == 2 || uiManager2.difficultymode == 3) {
			if (gameObject.tag == "redpug") {
				if (arenaHit == 18) {
					shooter.redcount--;
					shooter.pugCount--;
					Destroy (gameObject);
				}
			}
		}
	}
		
	void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.tag == "arena") {
			arenaHit++;
			am.glassTap.Play ();
			var em = ps.emission;
			em.enabled=true;
			StartCoroutine (stopEmission ());
			//StopCoroutine (stopEmission ());
			Ray2D ray = new Ray2D (transform.position, transform.right);
			RaycastHit2D hit = Physics2D.Raycast (transform.position, transform.right);
			if (Physics2D.Raycast (transform.position,transform.right, Time.deltaTime*speed+0.1f)) {
				Vector2 reflectdir = Vector2.Reflect (ray.direction,hit.normal);
				float rot = 40-Mathf.Atan2 (reflectdir.y, reflectdir.x) * Mathf.Rad2Deg;
				transform.eulerAngles = new Vector3 (0, 0, -rot);
			}
		
		}


    }

	IEnumerator stopEmission()
	{
		yield return new WaitForSeconds (0.5f);
		var em = ps.emission;
		em.enabled=false;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "destroyer") {
			Destroy (gameObject);
		}
	}
}



