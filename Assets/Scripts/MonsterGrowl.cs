using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGrowl : MonoBehaviour
{

    public AudioSource var;
    private float timer = 0.0f;

    void Start()
    {
        //var = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {

        timer += Time.deltaTime;

        if (timer%5f < 0.2f)
        {
            var.Play();
        }

    }
}
