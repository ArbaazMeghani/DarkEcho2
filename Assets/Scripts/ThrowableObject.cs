using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableObject : MonoBehaviour {

	public bool isObjectThrown;
	public GameObject waveProjector;
	public float waveDistanceMultiplier = 1.0f;
	public float initialVelocity = 1.0f;

	private Rigidbody throwableObjectRigidBody;

	void Start() {
		isObjectThrown = false;
		throwableObjectRigidBody = gameObject.GetComponent<Rigidbody> ();
	}

	void OnCollisionEnter(Collision other) {
		if (!isObjectThrown)
			return;

		GameObject waveProjectorInstance = Instantiate (waveProjector, 
			new Vector3(gameObject.transform.position.x, 8, gameObject.transform.position.z),
			waveProjector.transform.rotation);
		waveProjectorInstance.GetComponent<ProjectorMovement> ().waveDistance = initialVelocity * waveDistanceMultiplier;

		if (throwableObjectRigidBody.velocity == Vector3.zero)
			isObjectThrown = false;
	}
}
