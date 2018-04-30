using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour {

	void Start () {
		this.tag = transform.parent.tag;
	}

	void OnTriggerExit(Collider collider) {
		if (collider.gameObject.tag == "Ball") {
			Invoke ("FallDown", 0.5f);	
		}
	}

	void FallDown () {
		GetComponentInParent<Rigidbody> ().useGravity = true;
		GetComponentInParent<Rigidbody> ().isKinematic = false;
		Destroy (transform.parent.gameObject, 2f);
	}
}
