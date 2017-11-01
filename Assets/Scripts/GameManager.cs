using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	private bool gotKey;

	void Start() {
		gotKey = false;
	}

	public void DoorOpen() {
		gotKey = true;
	}

	public bool isDoorOpen() {
		return gotKey;
	}
}
