using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKeyCollect : MonoBehaviour {

    public AudioSource var;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            var.Play();
        }
    }
}
