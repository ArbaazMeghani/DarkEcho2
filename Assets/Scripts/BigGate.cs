using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigGate : MonoBehaviour {

	private void OnTriggerEnter(Collider other) {
		Debug.Log ("DOOR COLLISION!!");
		if(other.gameObject.CompareTag("Player") && FindObjectOfType<GameManager>().isDoorOpen()){
			Destroy (gameObject);
		}
	}
}
