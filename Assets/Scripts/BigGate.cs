using UnityEngine;

public class BigGate : MonoBehaviour {

	private Animator animationController;

	private void Start() {
		animationController = gameObject.GetComponent<Animator> ();
	}

	private void OnTriggerEnter(Collider other) {
		Debug.Log ("DOOR COLLISION!!");
		if(other.gameObject.CompareTag("Player") && FindObjectOfType<GameManager>().isDoorOpen()){
			animationController.SetBool ("GateOpen", true);
		}
	}

	private void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag ("Player"))
			animationController.SetBool ("GateOpen", false);
	}
}
