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

        if (promptKey == true)
        {

            sparks.Stop(includeChildren);
            damageAmount = 0;

        }

        other.SendMessage((isDamaging) ? "TakeDamage" : "TakeDamage", Time.deltaTime * damageAmount);
    }

   
}
