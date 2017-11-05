using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float movementSpeed = 5.0f;
	public Rigidbody movement;
	public Transform waveLocation;
	public Transform cameraDirection;
	public GameObject waveProjector;
	public float stepInterval = 0.5f;
	public AudioSource footStep;

	private float nextStep;
	private bool isMoving;
	private MainMonsterMovement mainMonster;
    private Secondary_Monster secondaryMonster;

	void Start() {
		nextStep = 0.0f;
		isMoving = false;
		mainMonster = FindObjectOfType<MainMonsterMovement> ();
        secondaryMonster = FindObjectOfType<Secondary_Monster>();
	}

	void FixedUpdate () {
		float horizontalMovement = Input.GetAxis ("Horizontal");
		float verticalMovement = Input.GetAxis ("Vertical");

		horizontalMovement *= Time.deltaTime * movementSpeed;
		verticalMovement *= Time.deltaTime * movementSpeed;

		if (horizontalMovement != 0.0f || verticalMovement != 0.0f)
			isMoving = true;
		else
			isMoving = false;
		cameraDirection.Translate (new Vector3 (horizontalMovement, 0.0f, verticalMovement));

		if (nextStep < Time.time && isMoving)
			CreateWave ();
	}

	void CreateWave() {
		if(!footStep.isPlaying)
			footStep.Play ();
		
		GameObject wave = Instantiate (waveProjector, 
			new Vector3 (waveLocation.position.x, 8.0f, waveLocation.position.z), 
			waveProjector.transform.rotation);

		mainMonster.soundCreated (wave);
 //       secondaryMonster.soundCreated(wave);

		nextStep = Time.time + stepInterval;
	}

	void OnCollisionEnter(Collision other) {
		if (other.gameObject.CompareTag ("Wall"))
			CreateWave ();
	}
}
