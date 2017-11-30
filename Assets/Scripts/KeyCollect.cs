using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollect : MonoBehaviour {

    public AudioSource var;

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player")) {
			FindObjectOfType<GameManager> ().DoorOpen ();
			Destroy (gameObject);
		}
	}
}
