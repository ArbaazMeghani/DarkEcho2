using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {


    public void LastLevel()
    {
        SceneManager.LoadScene(6);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(5);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void LevelSelect()
    {
        SceneManager.LoadScene(4);
    }

    public void Credits()
    {
        SceneManager.LoadScene(3);
    }

    public void AboutUs()
    {
        SceneManager.LoadScene(2);
    }

    public void Story()
    {
        SceneManager.LoadScene(1);
    }

    public void ReturntoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
