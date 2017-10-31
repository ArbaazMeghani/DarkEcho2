using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour {

	private bool isOpen = false;

	void Start() {
		if (gameObject.transform.rotation.y != 0)
			isOpen = true;
	}

	void OnTriggerEnter(Collider other) {
		if (!other.CompareTag ("Player"))
			return;

		HandleDoor ();
	}

	void HandleDoor() {
		if (!isOpen) {
			isOpen = true;
			StartCoroutine (OpenDoor());
		} else {
			isOpen = false;
			StartCoroutine (CloseDoor());
		}
	}

	IEnumerator OpenDoor() {
		while (gameObject.transform.rotation.y < 0.75f) {
			gameObject.transform.Rotate (new Vector3 (0.0f, 1.5f, 0.0f));
			yield return new WaitForSeconds (0.001f);
		}
	}

	IEnumerator CloseDoor() {
		while (gameObject.transform.rotation.y > 0.0f) {
			gameObject.transform.Rotate (new Vector3 (0.0f, -1.5f, 0.0f));
			yield return new WaitForSeconds (0.001f);
		}
	}


}
