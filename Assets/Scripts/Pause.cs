using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
    public Canvas pauseCanvas;

    // Use this for initialization
    void Start () {
        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.M))
        {
            (GameObject.Find("Player").GetComponent("MouseLock") as MonoBehaviour).enabled = false;
            (GameObject.Find("Main Camera").GetComponent("MouseLock") as MonoBehaviour).enabled = false;

            pauseCanvas = GetComponent<Canvas>();
            pauseCanvas.enabled = true;

            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }   
	}

    public void Resume()
    {
        (GameObject.Find("FirstPersonController").GetComponent("MouseLock") as MonoBehaviour).enabled = true;
        (GameObject.Find("Main Camera").GetComponent("MouseLock") as MonoBehaviour).enabled = true;

        pauseCanvas = GetComponent<Canvas>();
        pauseCanvas.enabled = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
