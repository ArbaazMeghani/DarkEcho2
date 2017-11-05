using UnityEngine;

public class LockedDoor : MonoBehaviour
{


    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("LOCKED DOOR COLLISION!!");
            audioSource.Play();
        }
    }
}