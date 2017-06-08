using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class uiManager : MonoBehaviour {

	public Text scoreText;
	public Text easy,medium,insane,survival;
	int score;
	public GameObject MenuPanel;
	public GameObject DifficultyPanel,optionsPanel,scorePanel;
	public GameObject Sound;
	Image image;
	public Sprite soundoff;


	void Start () {
		score = 0;
		image = Sound.GetComponent<Image> ();
	}
	

	void Update () {
		if (uiManager2.survivalmode == false && uiManager2.difficultymode==1) {  //*********************Easy Mode highscore*****************************
			scoreText.text = "" + score;
			score = player.score;
			if (PlayerPrefs.GetFloat ("HighscoreEasy") < score) {
				PlayerPrefs.SetFloat ("HighscoreEasy", score);
			}
		}
		if (uiManager2.survivalmode == false && uiManager2.difficultymode==2) {  //*********************Medium Mode highscore*****************************
			scoreText.text = "" + score;
			score = player.score;
			if (PlayerPrefs.GetFloat ("HighscoreMedium") < score) {
				PlayerPrefs.SetFloat ("HighscoreMedium", score);
			}
		}
		if (uiManager2.survivalmode == false && uiManager2.difficultymode==3) {  //*********************Insane Mode highscore*****************************
			scoreText.text = "" + score;
			score = player.score;
			if (PlayerPrefs.GetFloat ("HighscoreInsane") < score) {
				PlayerPrefs.SetFloat ("HighscoreInsane", score);
			}
		}

		if (audioManager.soundCheck == false) {  //*********************change audio sprite*****************************
			image.sprite = soundoff;
		}
	}

	public void Exit()
	{
		Application.Quit();
	}

	public void ArcadeEasy()   //*********************Easy Mode*****************************
	{
		uiManager2.checker = 1;
		uiManager2.difficultymode = 1;
		Pug.speed = 1f;
		shooter.maxPugCount = 6;
		shooter.maxRedCount = shooter.maxGreenCount = 4;
		SceneManager.LoadScene ("Arcade", LoadSceneMode.Single);
	}
	public void ArcadeMedium()     //*********************Medium Mode*****************************
	{
		uiManager2.checker = 1;
		uiManager2.difficultymode = 2;
		Pug.speed = 2.5f;
		shooter.maxPugCount = 7;
		shooter.maxRedCount = shooter.maxGreenCount = 5;
		SceneManager.LoadScene ("Arcade", LoadSceneMode.Single);
	}
	public void ArcadeInsane()    //*********************Insane Mode*****************************
	{
		uiManager2.checker = 1;
		uiManager2.difficultymode = 3;
		Pug.speed = 3.3f;
		shooter.maxPugCount = 9;
		shooter.maxRedCount = shooter.maxGreenCount = 7;
		SceneManager.LoadScene ("Arcade", LoadSceneMode.Single);
	}

	public void Back()   //*********************back button*****************************
	{
		DifficultyPanel.SetActive (false);
		MenuPanel.SetActive (true);
		optionsPanel.SetActive (true);
		scorePanel.SetActive (false);
	}

	public void Survival()   //*********************Survival Mode*****************************
	{
		uiManager2.checker = 2;
		uiManager2.difficultymode = 4;
		Pug.speed = 2.8f;
		shooter.maxPugCount = 9;
		shooter.maxRedCount = 9;
		shooter.maxGreenCount = 0;
		SceneManager.LoadScene ("Arcade", LoadSceneMode.Single);
	}
		
	public void DifficultyPanelSwitch()
	{
		DifficultyPanel.SetActive (true);
		optionsPanel.SetActive (false);
		MenuPanel.SetActive (false);
	}

	public void HighscorePanel()   //*********************Highscore display*****************************
	{
		MenuPanel.SetActive (false);
		scorePanel.SetActive (true);
		optionsPanel.SetActive (false);
		easy.text = "EASY : " + PlayerPrefs.GetFloat ("HighscoreEasy");
		medium.text = "MEDIUM : " + PlayerPrefs.GetFloat ("HighscoreMedium");
		insane.text = "INSANE : " + PlayerPrefs.GetFloat ("HighscoreInsane");
		survival.text = "SURVIVAL : " + PlayerPrefs.GetFloat ("HighscoreSurvival").ToString("F2") + "sec";

	}

	public void MenuSwitch()
	{
		uiManager2.survivalmode = false;
		SceneManager.LoadScene ("Menu", LoadSceneMode.Single);
	}
		

	public void Retry()     //**************************RETRY BUTTON************************
	{
		if (uiManager2.difficultymode == 1) {
			GetComponent<uiManager2> ().tutorialArcade.SetActive (false);
			ArcadeEasy ();
		} else if (uiManager2.difficultymode == 2) {
			GetComponent<uiManager2> ().tutorialArcade.SetActive (false);
			ArcadeMedium ();
		} else if (uiManager2.difficultymode == 3) {
			GetComponent<uiManager2> ().tutorialArcade.SetActive (false);
			ArcadeInsane ();
		}else if (uiManager2.difficultymode == 4) {
			GetComponent<uiManager2> ().tutorialSurvival.SetActive (false);
			Survival ();
		}

	}


}
