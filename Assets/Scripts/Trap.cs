﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

	public GameObject debris;
	public Transform debrisSpawnLocation;

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag ("Player"))
			Instantiate (debris, debrisSpawnLocation);
	}
}