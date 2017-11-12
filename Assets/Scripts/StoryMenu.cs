﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StoryMenu : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene(5);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

}