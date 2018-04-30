using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour {

	public static GameManger instance;
	public bool gameover;

	void Awake () {
		if (instance == null) {
			instance = this;
		}
	}

	void Start () {
		gameover = false;
	}

	public void StartGame () {
		UIManager.instance.GameStart ();
		ScoreManager.instance.StartScore ();
		GameObject.Find ("PlatformSpawner").GetComponent<PlatformSpawner> ().StartSpawing ();
	}

	public void GameOver () {
		gameover = true;
		UIManager.instance.GameOver ();
		ScoreManager.instance.StopScore ();
	}
}
