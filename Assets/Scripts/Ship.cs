using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {

	public int rotspeed=10;
	public static float dis;
	public Transform play;
	//float timer = 20f;

	void Update () {
		
		if (play != null) {
			dis = Vector2.Distance (transform.position, play.position);
			transform.Rotate (new Vector3 (0, 0, rotspeed) * Time.deltaTime);
		}
	}
}
