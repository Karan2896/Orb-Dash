using UnityEngine;
using System.Collections;

public class shooter : MonoBehaviour {

	public GameObject[] laser;
	public float time=3f;
	public static int pugCount;
	public static int redcount,greencount;
	public static bool check;
	int ran;
	public static int maxPugCount,maxRedCount,maxGreenCount;

	void Start()
	{
		pugCount = 0;
		redcount = greencount = 0;
		check = true;
	}

	void Update () {
		time -= Time.deltaTime;
		if (time < 0) {
			

			if (pugCount < maxPugCount) {
				ran = Random.Range (0,2);
				if (check == true) {
					if (ran == 0) {
						greencount++;
					} else if (ran == 1) {
						redcount++;
					}
				}
				if (redcount > maxRedCount) {
					check = false;
					redcount--;
					greencount++;
					ran = 0;
				}
				if (greencount > maxGreenCount) {
					greencount--;
					redcount++;
					ran = 1;
				}
				Instantiate (laser [ran], transform.position, transform.rotation);
				pugCount++;
			} else {
				check = false;
			}
			//Debug.Log ("green :"+greencount);
			//Debug.Log ("red :" + redcount);
			//Debug.Log ("pugs "+ pugCount);
			time = 3f;
		}

	}


}
