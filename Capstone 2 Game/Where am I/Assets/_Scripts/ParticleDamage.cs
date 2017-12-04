using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDamage : MonoBehaviour {

    public bool isDamaging = true;
    public float damageAmount = 10;
    float prevDamage;
    public bool interactable;
    public bool isVent;

    GameObject player;

    GameObject vent;


    

    // Use this for initialization
    void Start ()
    {
        player = transform.Find("/Player").gameObject;
        prevDamage = damageAmount;

        if(isVent == true)
            vent = this.transform.Find("Vent").gameObject;
        
        

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (player.GetComponent<Swim>().canSwim == true)
            damageAmount = damageAmount / 2;

       else if (player.GetComponent<Swim>().canSwim == false)
           damageAmount = prevDamage;
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
        AudioSource audio = GetComponentInChildren<AudioSource>();
        if (interactable == true && other.tag == "Player" && (Input.GetKeyDown(KeyCode.E)) && other.GetComponent<PlayerEffects>().hasTool == true)
        {
            
            vent.tag = "Vent";
            sparks.Stop(includeChildren);
            isDamaging = false;
            damageAmount = 0;
            audio.Stop();
            other.GetComponent<PlayerEffects>().numVentClosed++;


        }

       

    }

   
}
