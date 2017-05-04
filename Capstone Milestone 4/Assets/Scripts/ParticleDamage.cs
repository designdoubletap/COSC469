using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDamage : MonoBehaviour {

    bool promptKey = false;

    public bool isDamaging = true;
    public float damageAmount = 10;

    

    // Use this for initialization
    void Start () {


        
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.E))
        {
            promptKey = true;
        }
    }


    //stops particle system
    ParticleSystem sparks
    {
        get
        {
            if (_CachedSparks == null)
                _CachedSparks = GetComponent<ParticleSystem>();
            return _CachedSparks;
        }
    }

    private ParticleSystem _CachedSparks;
    public bool includeChildren = true;

    void OnTriggerStay(Collider other)
    {
        AudioSource audio = GetComponent<AudioSource>();
        if (other.tag == "Player" && (Input.GetKeyDown(KeyCode.E)))
        {

            sparks.Stop(includeChildren);
            damageAmount = 0;
            audio.Stop();
            //AudioSource.Stop();
            

        }

        //other.SendMessage((isDamaging) ? "TakeDamage" : "TakeDamage", Time.deltaTime * damageAmount);
    }

   
}
