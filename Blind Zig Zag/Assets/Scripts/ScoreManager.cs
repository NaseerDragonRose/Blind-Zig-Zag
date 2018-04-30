using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance;

	public int score;
	public int highScore;
	public Text gameScore;

	void Awake () {
		if (instance == null) {
			instance = this;
		}
	}

	void Start () {
		score = 0;
		gameScore.text = score.ToString ();
		PlayerPrefs.SetInt ("score", score);
		if (PlayerPrefs.HasKey ("highScore")) {
			highScore = PlayerPrefs.GetInt ("highScore");
		} else {
			highScore = 0;
			PlayerPrefs.SetInt ("highScore", highScore);
		}
	}

	void IncrementScore () {
		score++;
		gameScore.text = score.ToString ();
	}

	public void StartScore () {
		InvokeRepeating ("IncrementScore", 0.1f, 0.5f);
	}

	public void StopScore () {
		CancelInvoke ("IncrementScore");
		PlayerPrefs.SetInt ("score", score);
		if (score > highScore) {
			PlayerPrefs.SetInt ("highScore", score);
		}
	}
}
