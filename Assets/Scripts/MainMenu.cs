using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
    public void LastLevel()
    {
        SceneManager.LoadScene("Level.End");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Alpha");
    }
    public void Tutorial()
    {
        SceneManager.LoadScene("Level.Tutorial");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void AboutUs()
    {
        SceneManager.LoadScene("AboutUs");
    }

    public void Story()
    {
        SceneManager.LoadScene("Story");
    }

    public void ReturntoMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
