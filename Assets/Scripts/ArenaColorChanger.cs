using UnityEngine;
using System.Collections;

public class ArenaColorChanger : MonoBehaviour {

	SpriteRenderer sp;
	public Color[] color;
	float timer = 0f;
	int index=0;
	int nextindex = 1;
	float fadetime=2.5f;
	float timeTochange=5f;
	// Use this for initialization
	void Start () {
		sp = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		timeTochange -= Time.deltaTime;
		if (timeTochange < 0) {
			if (timer < 1) {
				timer += Time.deltaTime / fadetime;
				sp.material.color = Color.Lerp (color [index], color [nextindex], timer);
			} else {
				index++;
				nextindex++;
				if (index == 3) {
					nextindex = 0;
				}
				if (index == 4) {
					index = 0;
					nextindex = 1;
				}
				timer = 0f;
				timeTochange = 5f;
			}

		}

		}
	
}

