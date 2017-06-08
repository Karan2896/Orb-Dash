using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class uiManager2 : MonoBehaviour {

	float timer;
	public Text scoreText;
	public static bool survivalmode,helpPanelisActive;
	public GameObject tutorialArcade,tutorialSurvival,pauseMenu,GameOverMenu;
	public GameObject frame,shooterPower,yellowframe,HelpPanel,help;
	public static int checker,difficultymode;
	bool pausecheck;
	Image image;
	public Sprite soundoff;
	public GameObject Sound;
	InterstitialAd interstitial;


	void Start () {
		RequestInterstitial ();
		timer = 0;
		pausecheck =helpPanelisActive= false;
		image = Sound.GetComponent<Image> ();

	}
	

	void Update () {
		if (survivalmode == true) {
			timer += Time.deltaTime;
			scoreText.text = "" + timer.ToString("F2");
			if (PlayerPrefs.GetFloat ("HighscoreSurvival") < timer) {
				PlayerPrefs.SetFloat ("HighscoreSurvival", timer);
			}
		}
		if (checker == 1) {
			tutorialArcade.SetActive (true);
			Time.timeScale = 0;
		} else if (checker == 2) {
			Time.timeScale = 0;
			tutorialSurvival.SetActive (true);
		}

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began && checker==1) {
			tutorialArcade.SetActive (false);
			checker = 0;
			Time.timeScale = 1;
		}
		if ( Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began && checker==2){
			tutorialSurvival.SetActive (false);
			survivalmode = true;
			checker = 0;
			Time.timeScale = 1;
		}

		if (Input.GetKeyDown (KeyCode.Escape) && pausecheck==false && helpPanelisActive==false && tutorialArcade.activeInHierarchy==false && GameOverMenu.activeInHierarchy==false && tutorialSurvival.activeInHierarchy==false) {  //to enable pause menu
			Time.timeScale = 0;
			pauseMenu.SetActive (true);
			pausecheck=(!pausecheck);
			help.SetActive (false);
		}
		else if (Input.GetKeyDown (KeyCode.Escape) && pausecheck==true && helpPanelisActive==false) { //to disable pause menu
			Time.timeScale = 1;
			pauseMenu.SetActive (false);
			pausecheck=(!pausecheck);
			help.SetActive (true);
		}

		if (Input.GetKeyDown (KeyCode.Escape) && helpPanelisActive==true) {  //close help panel
			Time.timeScale = 1;
			helpPanelisActive = false;
			HelpPanel.SetActive (false);
		}

		if (player.gameOver == true) {
			if (interstitial.IsLoaded()) {

				interstitial.Show();
			}
			GameOverMenu.SetActive (true);
			help.SetActive (false);
		}	


		if (pauseMenu.activeInHierarchy) {
			if (audioManager.soundCheck == false) {
				image.sprite = soundoff;
			}
		}

		if (player.bluecheck == true)  //turn on and off blue frame
			frame.SetActive (true);
		else
			frame.SetActive (false);

		if (player.yellowcheck == true) //turn on and off yellow frame
			yellowframe.SetActive (true);
		else
			yellowframe.SetActive (false);

		if (difficultymode == 2 || difficultymode == 3) {//activate power up shooter for medium and insane levels
			shooterPower.SetActive (true);
		}

		if (difficultymode == 1 || difficultymode == 4) {
			help.SetActive (false);
		}
			
	}

	public void helpPanelSwitch() //*******************Help Button**********************
	{
		if (HelpPanel.activeInHierarchy == false) {
			Time.timeScale = 0;
			helpPanelisActive = true;
			HelpPanel.SetActive (true);
		} else {
			Time.timeScale = 1;
			helpPanelisActive = false;
			HelpPanel.SetActive (false);
		}
	}

	private void RequestInterstitial()    //*******************INTERSTITIAL ADS********************
	{
		#if UNITY_ANDROID
		string adUnitId = "ca-app-pub-9507839955691620/9523289590";
		#elif UNITY_IPHONE
		string adUnitId = "INSERT_IOS_INTERSTITIAL_AD_UNIT_ID_HERE";
		#else
		string adUnitId = "unexpected_platform";
		#endif

		// Initialize an InterstitialAd.
		interstitial = new InterstitialAd(adUnitId);
		// Create an empty ad request.
		AdRequest request = new AdRequest.Builder ().Build ();
		// Load the interstitial with the request.
		interstitial.LoadAd(request);
		}

}
