using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	private Text sText;
	public int score;

	public void Start(){
		sText = GetComponent<Text>();
		sText.text = " Score: 0";
	}

	public void AddPoints(int points){
		score += points;
		sText.text = "Score: " + score.ToString ();
	}
}
