using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{


    private GameObject rat;
    public GameObject waveProjector;
    public float waveDistanceMultiplier;
    public float timer;
    private float speed;
    public Rigidbody rb;
    private float nextStep;
    public float stepInterval = 0.5f;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 3.0f;
    }

    void CreateWave()
    {
        GameObject wave = Instantiate(waveProjector,
            new Vector3(gameObject.transform.position.x, 8.0f, gameObject.transform.position.z),
            waveProjector.transform.rotation);

		wave.GetComponent<ScannerMovement> ().waveDistance = 20;

        nextStep = Time.time + stepInterval;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.isKinematic = true;
        rb.detectCollisions = false;

        timer += Time.deltaTime;

        if (timer % 1f < 0.1)
        {

            transform.Rotate(0, Random.Range(20, 165), 0);

        }
        transform.position += transform.forward * Time.deltaTime * speed;

		if (nextStep < Time.time) {
			CreateWave ();
			nextStep = Time.time + stepInterval;
		}
    }
}
