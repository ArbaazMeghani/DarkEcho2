using System.Collections;
using UnityEngine;

public class DoorOpen : MonoBehaviour {

	public GameObject waveProjector;

	private bool isOpen = false;
	private MainMonsterMovement mainMonster;

	void Start() {
		if (gameObject.transform.rotation.y != 0)
			isOpen = true;

		mainMonster = FindObjectOfType<MainMonsterMovement> ();
	}

	void OnTriggerEnter(Collider other) {
		if (!other.CompareTag ("Player"))
			return;
		StopAllCoroutines ();

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
			CreateWave ();
			yield return new WaitForSeconds (0.001f);
		}
	}

	IEnumerator CloseDoor() {
		while (gameObject.transform.rotation.y > 0.0f) {
			gameObject.transform.Rotate (new Vector3 (0.0f, -1.5f, 0.0f));
			CreateWave ();
			yield return new WaitForSeconds (0.001f);
		}
	}

	void CreateWave() {
		GameObject waveProjectorInstance = Instantiate (waveProjector, 
			new Vector3 (gameObject.transform.position.x, 8.0f, gameObject.transform.position.z), 
			waveProjector.transform.rotation);
		mainMonster.soundCreated (waveProjectorInstance);
	}


}
