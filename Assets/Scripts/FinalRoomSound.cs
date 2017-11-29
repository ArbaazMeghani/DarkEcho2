using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRoomSound : MonoBehaviour {

	private AudioSource finalSound;
    public AudioSource var;

	void Start() {
		finalSound = GetComponent<AudioSource> ();
	}
	void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            var.Stop();
            finalSound.Play();
        }
	}

	void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            finalSound.Stop();
            var.Play();
        }
    }
}
