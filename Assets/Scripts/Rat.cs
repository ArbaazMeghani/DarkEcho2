using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rat : MonoBehaviour
{


    private GameObject rat;
    public float timer;
    private float speed;
    // Use this for initialization
    void Start()
    {
        rat = GameObject.Find("Rat");
        speed = 10.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltatime;

        transform.position += Vector3.forward * Time.deltaTime;

        if (timer % 5f < 0.1)
        {

            //currently goes in circles, rotates every 5 seconds
            //Randomness wasnt working properly so i removed it and going to start from scratch
            transform.rotate(0, 90, 0);

        }
    }
}
