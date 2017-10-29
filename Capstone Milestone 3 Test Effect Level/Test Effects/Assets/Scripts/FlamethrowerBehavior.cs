using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerBehavior : MonoBehaviour {

    public float offSetTime;
    public float waitTime;
    float startTime;

    

    private Component children;

	// Use this for initialization
	void Start ()
    {
        

        children = GetComponentInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update ()
    {

        if(flames.isPlaying == true)
        {
            StartCoroutine(Wait(waitTime));
        }
        else if(flames.isPlaying == false)
        {
            StartCoroutine(WaitToPlay(offSetTime));
        }

        
        
	}

    

    ParticleSystem flames
    {
        get
        {
            if (_CachedSystem == null)
                _CachedSystem = GetComponent<ParticleSystem>();
            return _CachedSystem;
        }
    }

    private ParticleSystem _CachedSystem;
    public bool includeChildren = true;


    

    IEnumerator OffSet(float oT)
    {
       yield return new WaitForSeconds(oT);
    }

    IEnumerator Wait(float w)
    {
        yield return new WaitForSeconds(w);
        flames.Stop();
    }

    IEnumerator WaitToPlay(float o)
    {
        yield return new WaitForSeconds(o);
        flames.Play();
        GetComponentInParent<AudioSource>().Play();
       
        
    }

}
