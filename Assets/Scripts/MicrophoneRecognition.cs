using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneRecognition : MonoBehaviour {

    public float waveDistanceMultiplier;
    public GameObject waveProjector;
    public float stepInterval = 0.5f;
    private float nextStep;
    public bool micOnStart = true, stopListener = false, startListener = false, listenerOn = false, outputSound = false;
    AudioSource mic;
    public AudioMixer mixer;
    float timer = 0;
    float amplitude;
    int sampleNums = 4096; //this may need to be changed when we figure out what actually needs to be inserted in the function
    private float[] samples;
	// Use this for initialization
	void Start () {

        samples = new float[sampleNums];
        if (micOnStart)
        {
            RestartListener();
            StartListener();
        }
		
	}

    void CreateWave()
    {
        Instantiate(waveProjector,
            new Vector3(gameObject.transform.position.x, 8.0f, gameObject.transform.position.z),
            waveProjector.transform.rotation);

        nextStep = Time.time + stepInterval;
    }

    // Update is called once per frame
    void Update () {

        if (stopListener)
        {
            StopListener();
        }
        if (startListener)
        {
            StartListener();
        }

        stopListener = false;
        startListener = false;

        MicToSource(listenerOn);

        amplitude = RMS(0) + RMS(1);

        if (amplitude > .01)
        {
            CreateWave();
        }

        DisableSound(outputSound);
	}

    public void StopListener()
    {
        listenerOn = false;
        outputSound = true;
        mic.Stop();
        mic.clip = null;

        Microphone.End(null);
    }

    public void StartListener()
    {
        listenerOn = true;
        outputSound = false;
        RestartListener();
    }

    public void DisableSound(bool output)
    {
        float volume = 0;


        if (output)
        {
            volume = 0.0f;
        }

        else
        {
            volume = -80.0f;
        }

        mixer.SetFloat("Master Volume", volume);
    }

    public void RestartListener()
    {
        mic = GetComponent<AudioSource>();
        mic.clip = null;
        timer = Time.time;
    }

    void MicToSource(bool listener)
    {
        if (listener)
        {
            if (Time.time-timer > 0.5f && !Microphone.IsRecording(null))
            {
                mic.clip = Microphone.Start(null, true, 10, 44100);



                while (!(Microphone.GetPosition(null) > 0))
                {
                    //purposely empty, just to make sure mic is functioning
                }
                mic.Play();

                
            }
        }
    }

    float RMS(int channel)
    {
        //currently need to find the int value to make function work, the value is what it finds amplitude for
        AudioListener.GetOutputData(samples, channel);

        float total = 0;

        foreach(float x in samples)
        {
            total += x * x;
        }
        return Mathf.Sqrt(total / sampleNums);

		return 0.0f;
    }
}
