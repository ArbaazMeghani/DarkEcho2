using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
    /*
    public void QuitGame()
    {
        Application.Quit();
    }*/
}
