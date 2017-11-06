using UnityEngine;

public class BigGate : MonoBehaviour {

	private Animator animationController;
    public AudioSource[] AudioClips = null;
   // AudioSource doorOpen;
   // AudioSource doorClose;

    private void Start() {
		animationController = gameObject.GetComponent<Animator> ();
      //  doorOpen = GetComponent<AudioSource>();
      //  doorClose = GetComponent<AudioSource>(); 
    }

	private void OnTriggerEnter(Collider other) {
		Debug.Log ("DOOR COLLISION!!");
		if(other.gameObject.CompareTag("Player") && FindObjectOfType<GameManager>().isDoorOpen()){
			animationController.SetBool ("GateOpen", true);
            AudioClips[0].Play();
        }
	}

	private void OnTriggerExit(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            animationController.SetBool("GateOpen", false);
            AudioClips[1].Play();
        }
    }
}
