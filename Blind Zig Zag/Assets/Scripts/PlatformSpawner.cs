using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

	public GameObject platform;
	public GameObject diamond;
	private string lastPlatform = "x";

	Vector3 lastPosition;
	GameObject previousPlatform;
	float size;

	// Use this for initialization
	void Start () {
		lastPosition = platform.transform.position;
		size = platform.transform.localScale.x;
		for (int i = 0; i < 15; i++)
			SpawnPlatforms ();
	}
	
	// Update is called once per frame
	void Update () {
		if (GameManger.instance.gameover) {
			CancelInvoke ("SpawnPlatforms");
		}
	}

	public void StartSpawing () {
		InvokeRepeating ("SpawnPlatforms", 2f, 0.2f);
	}

	void SpawnPlatforms () {
		int random = Random.Range (0, 7);
		if (random > 3) {
			SpawnX ();
		} else {
			SpawnZ ();
		}
	}

	void SpawnDiamond (Vector3 position, GameObject newPlatform) {
		previousPlatform = newPlatform;
		int random = Random.Range (0, 4);
		position.y = diamond.transform.position.y;
		if (random < 1) {
			GameObject item = Instantiate (diamond, position, diamond.transform.rotation) as GameObject;
			item.transform.parent = newPlatform.transform;
		}
	}

	void SpawnX () {
		Vector3 position = lastPosition;
		position.x += size;
		lastPosition = position;
		GameObject newPlatform = Instantiate (platform, position, Quaternion.identity) as GameObject;
		if (lastPlatform == "z") {
			previousPlatform.tag = "LeftPlatform";
		}
		lastPlatform = "x";
		SpawnDiamond (position, newPlatform);
	}

	void SpawnZ () {
		Vector3 position = lastPosition;
		position.z += size;
		lastPosition = position;
		GameObject newPlatform = Instantiate (platform, position, Quaternion.identity);
		if (lastPlatform == "x") {
			previousPlatform.tag = "RightPlatform";
		}
		lastPlatform = "z";
		SpawnDiamond (position, newPlatform);
	}
}
