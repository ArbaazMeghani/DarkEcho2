using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {

    public GameObject blackDebris;
    public GameObject redDebris;
    public GameObject cinderDebris;
    public GameObject moreDebris;

    public GameObject light1;
    public GameObject light2;
    public GameObject light3;
    public GameObject light4;

    public Transform debrisSpawnWin1;
    public Transform debrisSpawnWin2;
    public Transform debrisSpawnWin3;
    public Transform debrisSpawnWin4;

    //AudioSource audioSource;
    public AudioSource[] AudioClips = null;

    private bool trigger = false;
    private float timer = 0f;
    // Use this for initialization
    void Start () {
        //audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (trigger == true)
        {
            timer += Time.deltaTime;

            if(timer % 1 < 0.01f)
            {
                Instantiate(moreDebris, debrisSpawnWin1);
                Instantiate(blackDebris, debrisSpawnWin1);
                Instantiate(redDebris, debrisSpawnWin1);
                Instantiate(cinderDebris, debrisSpawnWin1);

                Instantiate(moreDebris, debrisSpawnWin2);
                Instantiate(blackDebris, debrisSpawnWin2);
                Instantiate(redDebris, debrisSpawnWin2);
                Instantiate(cinderDebris, debrisSpawnWin2);

                Instantiate(moreDebris, debrisSpawnWin3);
                Instantiate(blackDebris, debrisSpawnWin3);
                Instantiate(redDebris, debrisSpawnWin3);
                Instantiate(cinderDebris, debrisSpawnWin3);

                Instantiate(moreDebris, debrisSpawnWin4);
                Instantiate(blackDebris, debrisSpawnWin4);
                Instantiate(redDebris, debrisSpawnWin4);
                Instantiate(cinderDebris, debrisSpawnWin4);
                Debug.Log("Final Room Debris Falling");

				light1.GetComponent<Light> ().enabled = true;
            }
            if (timer % 2 < 0.01f)
            {
				light2.GetComponent<Light> ().enabled = true;
            }
            if (timer % 3 < 0.01f)
            {
				light3.GetComponent<Light> ().enabled = true;
            }
            if (timer % 4 < 0.01f)
            {
				light4.GetComponent<Light> ().enabled = true;
            }

            if (timer > 8.1f)
            {
                FindObjectOfType<GameManager>().EndGame();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Win Button Pressed");
            trigger = true;
            //audioSource.Play();
            AudioClips[0].Play();
            AudioClips[1].Play();
        }
       
    }

}
