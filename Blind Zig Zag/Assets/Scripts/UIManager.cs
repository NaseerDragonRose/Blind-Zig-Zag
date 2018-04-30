using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour {

	public static UIManager instance;

	public GameObject titlePanel;
	public GameObject gameoverPanel;
	public GameObject startText;
	public GameObject gameScore;
	public Text endScore;
	public Text highScore1;
	public Text highScore2;

	void Awake () {
		if (instance == null) {
			instance = this;
		}
	}

	void Start () {
		highScore1.text = PlayerPrefs.GetInt ("highScore").ToString ();
	}

	public void GameStart () {
		startText.SetActive (false);
		gameScore.SetActive (true);
		titlePanel.GetComponent<Animator> ().Play ("PanelUp");
	}

	public void GameOver () {
		gameScore.SetActive (false);
		endScore.text = PlayerPrefs.GetInt ("score").ToString ();
		highScore2.text = PlayerPrefs.GetInt ("highScore").ToString ();
		gameoverPanel.SetActive (true);
	}

	public void Reset () {
		SceneManager.LoadScene (0);
	}
}

