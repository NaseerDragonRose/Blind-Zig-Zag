using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject ball;
	public bool gameover;

	float lerpRate = 2f;

	Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = ball.transform.position - transform.position;
		gameover = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!gameover) {
			Follow ();
		}
	}

	void Follow () {
		Vector3 initialPositon = transform.position;
		Vector3 targetPosition = ball.transform.position - offset;
		initialPositon = Vector3.Lerp (initialPositon, targetPosition, lerpRate * Time.deltaTime);
		transform.position = initialPositon;
	}
}
