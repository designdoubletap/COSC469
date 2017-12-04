using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    //environment audio
    public AudioSource[] environtmentSounds;

    //object sounds
    public AudioSource[] objectSounds;

    //player sounds
    public AudioSource[] playerSounds;

    public AudioSource ringing;




	// Use this for initialization
	void Start ()
    {
        for (int i = 0; i < environtmentSounds.Length; i++)
        {
            environtmentSounds[i].GetComponent<AudioSource>().volume = .7f;
        }

        for (int i = 0; i < objectSounds.Length; i++)
        {
            objectSounds[i].GetComponent<AudioSource>().volume = .5f;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void LowerVolume()
    {
        for (int i = 0; i < environtmentSounds.Length; i++)
        {
            environtmentSounds[i].GetComponent<AudioSource>().volume = .3f;

        }

        for (int i = 0; i < objectSounds.Length; i++)
        {
            objectSounds[i].GetComponent<AudioSource>().volume = .2f;
        }

        ringing.GetComponent<AudioSource>().Play();
        ringing.GetComponent<AudioSource>().volume = .03f;
    }

    public void RaiseVolume()
    {
        for (int i = 0; i < environtmentSounds.Length; i++)
        {
            environtmentSounds[i].GetComponent<AudioSource>().volume = 1f;
        }

        for (int i = 0; i < objectSounds.Length; i++)
        {
            objectSounds[i].GetComponent<AudioSource>().volume = .7f;
        }

        ringing.GetComponent<AudioSource>().Stop();
    }

    public void ResetVolume()
    {
        for (int i = 0; i < environtmentSounds.Length; i++)
        {
            environtmentSounds[i].GetComponent<AudioSource>().volume = .7f;
        }


        for (int i = 0; i < objectSounds.Length; i++)
        {
            objectSounds[i].GetComponent<AudioSource>().volume = .5f;
        }

        ringing.GetComponent<AudioSource>().Stop();
    }

    public void PauseAll()
    {
        for (int i = 0; i < environtmentSounds.Length; i++)
        {
            environtmentSounds[i].GetComponent<AudioSource>().Pause();
        }

        
        for (int i = 0; i < objectSounds.Length; i++)
        {
            objectSounds[i].GetComponent<AudioSource>().Pause();
        }

        ringing.GetComponent<AudioSource>().Pause();
    }

    public void ResumeAll()
    {
        for (int i = 0; i < environtmentSounds.Length; i++)
        {
            environtmentSounds[i].GetComponent<AudioSource>().UnPause();
        }


        for (int i = 0; i < objectSounds.Length; i++)
        {
            objectSounds[i].GetComponent<AudioSource>().UnPause();
        }

        ringing.GetComponent<AudioSource>().UnPause();
    }
}
