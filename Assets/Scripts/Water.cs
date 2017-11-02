using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

	public PlayerController leftController;
	public PlayerController rightController;

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player")) {
			leftController.movementSpeed = 3;
			rightController.movementSpeed = 3;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.CompareTag ("Player")) {
			leftController.movementSpeed = 3;
			rightController.movementSpeed = 3;
		}
	}
}
