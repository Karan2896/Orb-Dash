using UnityEngine;
using System.Collections;

public class shootPower : MonoBehaviour {

	public GameObject[] laser;
	public float time=17f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if (time < 0) {
			int ran = Random.Range (0,2);
			Instantiate (laser [ran], transform.position, transform.rotation);
			time = 17f;
		}
	
	}
}
