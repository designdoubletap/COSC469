using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamageRoom : MonoBehaviour {

    bool promptKey = false;

    public bool isDamaging;
    public float damageAmount = 10;

    ParticleSystem vent1;
    ParticleSystem vent2;
    ParticleSystem vent3;

    // Use this for initialization
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {

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

  
    ParticleSystem _CachedSparks;
    public bool includeChildren = true;

  


    void OnTriggerEnter(Collider other)
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            //player takes damage as long as they remain in damage zone

            other.SendMessage((isDamaging) ? "TakeDamage" : "HealDamage", Time.deltaTime * damageAmount);

            if(promptKey == true)
            {
                sparks.Stop(includeChildren);
            }
        }

        
    }

}
