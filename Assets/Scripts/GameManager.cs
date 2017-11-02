using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
*   GameManager.cs
*   Manages the state of the game for the level.
*   A Key is required to go through the large green door. Once the key is obtained, the Player can open the door.
*   If a player is touched by a Monster, the player character dies and the level is reset.
*
*/


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
        //Death Code, the scene is reloaded.
		SceneManager.LoadScene ("Level.End");
	}
}
