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

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.K))
        {
            Debug.Log("Cheat Key Activated");
            gotKey = true;
        }
        if (Input.GetKey(KeyCode.L))
        {
            Debug.Log("Cheat Key Deactivated");
            gotKey = false;
        }
    }

	void Start() {
		gotKey = false;
	}

	public void DoorOpen() {
		gotKey = true;
	}

	public bool isDoorOpen() {
		return gotKey;
	}

    //Monster or Obstacle or Trap Death Code
	public void Die() {
        //When you die you are sent to the Game Over Screen
		SceneManager.LoadScene (7);
	}

    //If the light switch button is touched, the game ends and the player wins
    //we will model a more impressive button eventually
    public void EndGame()
    {
        //the Escaped GameOver Screen plays
        SceneManager.LoadScene(8);
        //Application.Quit();
    }
}
