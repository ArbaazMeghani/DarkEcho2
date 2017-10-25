using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float movementSpeed = 5.0f;
	public GameObject cameraRig;
	public GameObject waveProjector;
	public float stepInterval = 0.5f;

	private float nextStep;
	private bool isMoving;

	void Start() {
		nextStep = 0.0f;
		isMoving = false;
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

		cameraRig.transform.Translate (horizontalMovement, 0.0f, verticalMovement);

		if (nextStep < Time.time && isMoving)
			CreateWave ();
	}

	void CreateWave() {
		//TODO::play step audio.
		Instantiate (waveProjector, 
			new Vector3 (cameraRig.transform.position.x, 8.0f, cameraRig.transform.position.z), 
			waveProjector.transform.rotation);

		nextStep = Time.time + stepInterval;
	}
}
