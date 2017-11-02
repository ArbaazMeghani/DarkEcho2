using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player"))
			other.gameObject.GetComponent<PlayerController> ().movementSpeed = 3;
	}

	void OnTriggerExit(Collider other) {
		if (other.CompareTag ("Player"))
			other.gameObject.GetComponent<PlayerController> ().movementSpeed = 5;
	}
}
