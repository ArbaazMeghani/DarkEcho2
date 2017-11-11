using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void PlayGame()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void AboutUs()
    {
        SceneManager.LoadScene(2);
    }

    public void Story()
    {
        SceneManager.LoadScene(1);
    }


}
