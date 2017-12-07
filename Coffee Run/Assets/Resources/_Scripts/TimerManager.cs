using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TimerManager : MonoBehaviour {
	public Image timerBar;
	public float timeAmt = 100;
	public float time;
	public Text timeText;
	public GameObject GameOverPanel;
	public Text gameOverText;

	void Start () {
		GameOverPanel.SetActive (false);
		Time.timeScale = 1;
		timerBar = timerBar.GetComponent<Image> ();
		timeText = timeText.GetComponent<Text> ();
		time = timeAmt;
	}

	void Update () {
		if (time > 0) {
			time -= Time.deltaTime;
			timerBar.fillAmount = time / timeAmt;
			timeText.text = time.ToString ("N0");
		}

		if (time < 0) {
			GameOverPanel.SetActive (true);
			gameOverText.text = "Game Over";
			Time.timeScale = 0;
		}
	}
}
