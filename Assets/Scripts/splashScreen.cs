using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class splashScreen : MonoBehaviour {

	public float timer = 1.5f;

	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer < 0) {
			SceneManager.LoadScene ("Menu", LoadSceneMode.Single);
		}
	}
}
