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

        ringing.GetComponent<AudioSource>().Play();
        ringing.GetComponent<AudioSource>().volume = .03f;
    }

    public void RaiseVolume()
    {
        for (int i = 0; i < environtmentSounds.Length; i++)
        {
            environtmentSounds[i].GetComponent<AudioSource>().volume = 1f;
        }

        ringing.GetComponent<AudioSource>().Stop();
    }

    public void ResetVolume()
    {
        for (int i = 0; i < environtmentSounds.Length; i++)
        {
            environtmentSounds[i].GetComponent<AudioSource>().volume = .7f;
        }

        ringing.GetComponent<AudioSource>().Stop();
    }

    public void PauseAll()
    {
        for (int i = 0; i < environtmentSounds.Length; i++)
        {
            environtmentSounds[i].GetComponent<AudioSource>().Pause();
        }

        ringing.GetComponent<AudioSource>().Pause();
    }

    public void ResumeAll()
    {
        for (int i = 0; i < environtmentSounds.Length; i++)
        {
            environtmentSounds[i].GetComponent<AudioSource>().UnPause();
        }

        ringing.GetComponent<AudioSource>().UnPause();
    }
}
