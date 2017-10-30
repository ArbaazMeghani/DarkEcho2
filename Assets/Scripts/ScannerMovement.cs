using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerMovement : MonoBehaviour {

	public float speed = 5;
	public float waveDistance;

	private Light waveLight;

	void Start() {
		waveLight = gameObject.GetComponent<Light> ();
		waveLight.range = waveDistance;

	}

	// Update is called once per frame
	void Update () {
		gameObject.transform.SetPositionAndRotation (
			new Vector3 (gameObject.transform.position.x, gameObject.transform.position.y + (Time.deltaTime * speed), gameObject.transform.position.z), 
			gameObject.transform.rotation);

		if (gameObject.transform.position.y > waveLight.range)
			Destroy (gameObject);

	}
}
