using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

	public GameObject particle;
	public AudioClip diamondCollectSound;
	public AudioClip turnSound;

	private float speed = 2f;

	bool gameover;
	bool started;

	Rigidbody rigidBody;

	void Awake () {
		rigidBody = GetComponent<Rigidbody> ();
	}

	// Use this for initialization
	void Start () {
		gameover = false;
		started = false;
	}

	// Update is called once per frame
	void Update () {
		if (!started && Input.GetMouseButtonDown (0)) {
			started = true;
			GameManger.instance.StartGame ();
		}
		if (!Physics.Raycast (transform.position, Vector3.down, 1f)) {
			gameover = true;
			GameManger.instance.GameOver ();
			Camera.main.GetComponent<CameraController> ().gameover = true;
		}
		if (Input.GetMouseButtonDown (0) && !gameover) {
			ChangeDirection ();
		}
	}

	void ChangeDirection () {
		if (Input.mousePosition.x > Screen.width / 2) {
			rigidBody.velocity = new Vector3 (speed, 0, 0);
		} else if (Input.mousePosition.x < Screen.width / 2) {
			rigidBody.velocity = new Vector3 (0, 0, speed);
		}
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.tag == "Diamond") {
			ScoreManager.instance.score += 2;
			AudioSource.PlayClipAtPoint (diamondCollectSound, collider.transform.position);
			GameObject part = Instantiate (particle, collider.gameObject.transform.position, Quaternion.identity) as GameObject;
			Destroy (collider.gameObject);
			Destroy (part, 1f);
		}
		if (collider.tag == "LeftPlatform" || collider.tag == "RightPlatform") {
			AudioSource.PlayClipAtPoint (turnSound, transform.position);
		}
	}
}
