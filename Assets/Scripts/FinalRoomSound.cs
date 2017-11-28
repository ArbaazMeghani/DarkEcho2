using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRoomSound : MonoBehaviour {

	private AudioSource finalSound;

	void Start() {
		finalSound = GetComponent<AudioSource> ();
	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Player"))
			finalSound.Play ();
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag ("Player"))
			finalSound.Stop ();
	}
}
