using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

	public void Die() {
		SceneManager.LoadScene ("Level.End");
	}
}
