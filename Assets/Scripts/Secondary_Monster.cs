using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/***********************************************************************************
*   Author: Shawn Kim
*   Game Project: Dark Echo 2
*   Other Team: Arbaaz Meghani, Yao Chen, Giovanni Valencia
*   Description: This is a simple AI implementation. As the only graduate student in the class I have ill defined limitations
*   that confused me. Unfortunately by the time I actually had time to work on this assignment wednesday, I was so stressed
*   tired, and demoralized, that my attempts to use an advanced path finding technique simply failed and I was not able to ask
*   coherent questions to the TA via email. Instead, I created 
*   a much more simpler AI than I previously wanted that doesn't use the advanced pathfinding techniques.
*
*
*   Description of AI Behavior: This Monster "randomly" chooses a direction then moves a small randomized distance over 5 seconds. If the 
*   Monster detects a nearby sound, it will respond to it and move towards that sound instead. This Monster also moves slower
*   than the other Monster and acts more as an obstacle rather than an instant active threat since the other monster moves rather
*   quickly.
*
* 
*   The Death code implementation and the Sound wave related functionality is used from the Main Monster AI in order to standardize
*   the method of how the monsters kill the player or detect them/other sounds. 
************************************************************************************/
public class Secondary_Monster : MonoBehaviour {
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

        wave.GetComponent<ScannerMovement>().waveDistance = 20;

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

            transform.Rotate(0, Random.Range(-20, -165), 0);

        }
        transform.position += transform.forward * Time.deltaTime * speed;

        if (nextStep < Time.time)
        {
            CreateWave();
            nextStep = Time.time + stepInterval;
        }
    }
    
    /*

    
    
    
    
    
    */
    
    /*
    public float waveDistanceMultiplier;
    public GameObject waveProjector;

    public float stalkSpeed;
    private float nextStep;
    private Vector3 direction;
    //private GameObject target;
    private float distanceToSound;
    private float xAxis;
    private float zAxis;

    public float timer;
    private int directFlag;


    // Use this for initialization
    void Start () {
        waveDistanceMultiplier = 0.75f;
        stalkSpeed = 2.5f;
        directFlag = 0;
    }
	
	// Update is called once per frame
	void fixedUpdate () {

        timer += Time.deltaTime;

        //Every 5 seconds the monster chooses a new direction to wander in by random, that is IF the direction was not
        //set to be towards the player if the monster detects the player's sound waves.
        if (timer % 5f <= .5 && directFlag == 0)
        {
            wander();
        }
        //monster moves in its current direction
        stalk();

        if (nextStep < Time.time)
        {
            CreateWave();
        }
    }


    //Monsters create noise as well and thus draw from the sound wave creation code shared.
    void CreateWave()
    {
        Instantiate(waveProjector,
            new Vector3(gameObject.transform.position.x, 8.0f, gameObject.transform.position.z),
            waveProjector.transform.rotation);

        nextStep = Time.time + stalkSpeed;
    }
    //Monsters detect sounds. If they are close enough to a detected sound they will attempt to follow it..
    public void soundCreated(GameObject soundWave)
    {
        //the purpose of this code, is to determine the distance to the source of a detected sound.
        distanceToSound = Vector3.Distance(gameObject.transform.position, soundWave.transform.position);
        if (distanceToSound <= waveDistanceMultiplier * soundWave.GetComponent<ScannerMovement>().waveDistance)
        {
            direction = new Vector3(waveProjector.transform.position.x, waveProjector.transform.position.z);
            transform.Rotate(direction);
            directFlag = 1;
        }
        else
        {
            directFlag = 0;
        }
    }

    //randomized direction chosen unless if player is detected in vicinity via the soundCreated function called by
    //the Player Controller. PlayerController.cs
    public void wander()
    {
        //System.Random randomGen = new System.Random();
        //int randomNumber = randomGen.Next(0, 51);
 

        xAxis = Random.Range(-1f, 1f);
        zAxis = Random.Range(-1f, 1f);
        // direction = new Vector3(xAxis, 6.02f, zAxis);
        xAxis = Random.Range(0, 360);

        transform.Rotate(0, xAxis, 0);
    }

    //Moves the monster towards the chosen direction.
    public void stalk()
    {
        //The Monster stalks towards the direction vector
        //transform.Rotate(direction);

        // transform.position = Vector3.MoveTowards(transform.position, direction, stalkSpeed * Time.deltaTime);
        transform.position += transform.forward * Time.deltaTime * stalkSpeed;
    }


    //kills the player if the player touches the monster
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            FindObjectOfType<GameManager>().Die();
    }
    */
}
