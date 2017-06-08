using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class audioManager : MonoBehaviour {

	public AudioSource glassTap,playerHit,click,bgmusic;
	public static bool soundCheck= true;
	SpriteRenderer sp;
	Image image;
	public Sprite soundoff, soundon;
	public GameObject Sound;

	void Start()
	{
		//soundCheck = true;
		image = Sound.GetComponent<Image> ();
		bgmusic.Play ();
	}

	public void ClickSound()
	{
		click.Play ();
	}

	void Update()
	{
		if (soundCheck == false) {
			click.volume = glassTap.volume = playerHit.volume = bgmusic.volume = 0;
		}
	}

	public void SoundSwitch()
	{
		if (soundCheck == true) {
			image.sprite = soundoff;
			soundCheck = false;
			click.volume = 0;
		} else if (soundCheck == false) {
			image.sprite = soundon;
			soundCheck = true;
			click.volume = 0.4f;
		}
	}

	public void SoundSwitchGame()
	{
		if (soundCheck == true) {
			image.sprite = soundoff;
			soundCheck = false;
			click.volume = glassTap.volume = playerHit.volume= bgmusic.volume= 0;

		} else if (soundCheck == false) {
			image.sprite = soundon;
			soundCheck = true;
			click.volume = 0.4f;
			glassTap.volume = 0.3f;
			playerHit.volume = 0.2f;
			bgmusic.volume = 0.7f;
		}
	}
}
