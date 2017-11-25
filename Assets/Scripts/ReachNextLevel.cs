﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReachNextLevel : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Stairs to Next Level Reached!");
        if (other.gameObject.CompareTag("Player"))
            {
                SceneManager.LoadScene("Level.End");
            }
    }
    /*
    public void QuitGame()
    {
        Application.Quit();
    }*/
}
