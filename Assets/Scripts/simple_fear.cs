using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class simple_fear : MonoBehaviour
{

    private GameObject fear;
    public GameObject waveProjector;
    private GameObject hide;
    private Vector3 hidePosition;

    public float timer;
    private float speed;
    public Rigidbody rb;

    public float waveDistanceMultiplier;
    private float nextStep;
    public float stepInterval = 0.5f;
    private bool flag;
    private bool turn;
    // Use this for initialization
    void Start()
    {
        hide = GameObject.Find("Door");
        flag = false;
        turn = true;
        rb = GetComponent<Rigidbody>();
        speed = 4.0f;
    }

    void CreateWave()
    {
        GameObject wave = Instantiate(waveProjector,
            new Vector3(gameObject.transform.position.x, 8.0f, gameObject.transform.position.z),
            waveProjector.transform.rotation);

        wave.GetComponent<ScannerMovement>().waveDistance = 20;

        nextStep = Time.time + stepInterval;
    }

    public void soundCreated(GameObject soundWave)
    {
        float distanceToSound = Vector3.Distance(gameObject.transform.position, soundWave.transform.position);
        if (distanceToSound <= waveDistanceMultiplier * soundWave.GetComponent<ScannerMovement>().waveDistance)
        {
            flag = true;
            //  transform.position();
            Debug.Log("New Destination Set");
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.isKinematic = true;
        rb.detectCollisions = true;

        timer += Time.deltaTime;
        //transform.position += transform.forward * Time.deltaTime * speed;
        if (flag == false)
        {
            if (timer % 3f < 0.1)
            {

                transform.Rotate(0, Random.Range(40, 120), 0);

            }

            transform.position += transform.forward * Time.deltaTime * speed;
        }
        else
        {
            speed = 8.0f;
            // hidePosition = new Vector3(hide.transform.position.x, hide.transform.position.y, hide.transform.position.z);

            if (turn == true)
            {
                transform.Rotate(13.68f, -7.9572f, -43.451f );
                turn = false;
            }

            //transform.position = Vector3.MoveTowards(transform.position, hidePosition, speed * Time.deltaTime);
            transform.position += transform.forward * Time.deltaTime * speed;


        }


        if (nextStep < Time.time)
        {
            CreateWave();
            nextStep = Time.time + stepInterval;
        }
    }
}
