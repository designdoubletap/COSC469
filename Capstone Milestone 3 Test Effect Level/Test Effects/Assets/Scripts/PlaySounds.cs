using UnityEngine;
using System.Collections;

public class PlaySounds : MonoBehaviour {


    public AudioClip soundClip;
    //public float volume;
    AudioSource audio;


	// Use this for initialization
	void Start () {

        audio = GetComponent<AudioSource>();
	}
	

	void OnTriggerEnter (Collider other) {

        if (!audio.isPlaying && other.tag == "Player")
        {
            audio.clip = soundClip;
            audio.Play();
        }
	}
}
