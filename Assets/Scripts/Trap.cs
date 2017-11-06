using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//idea for delayed timer:
//https://answers.unity.com/questions/502127/how-to-enable-gravity-on-gameobject-when-interact.html
public class Trap : MonoBehaviour {

	public GameObject blackDebris;
    public GameObject redDebris;
    public GameObject cinderDebris;
    public GameObject moreDebris;
    public Transform debrisSpawnLocation;
    public float delay = 0.6f;
    private bool trigger = false;
    private float timer = 0f;

    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trigger = true;

            //audio plays and gives the player a chance to move out of the way due to the delay
            audioSource.Play();
            if (timer > delay)
            {
                //blackDebris.attachedRigidbody.useGravity = true;
                // other.attachedRigidbody.isKinematic = false;

                Instantiate(moreDebris, debrisSpawnLocation);
               // moreDebris.GetComponent<Rigidbody>().angularVelocity = transform.rotation * ((20 * 30 * Mathf.Deg2Rad) / Time.deltaTime);
                Instantiate(blackDebris, debrisSpawnLocation);
                Instantiate(redDebris, debrisSpawnLocation);
                Instantiate(cinderDebris, debrisSpawnLocation);
                Debug.Log("debris falling");
            }

        }
    }

    void Update()
    {
        if(trigger == true)
        {
            timer += Time.deltaTime;

        }
    }
}
