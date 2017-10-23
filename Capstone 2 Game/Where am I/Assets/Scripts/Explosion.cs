using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public GameObject explosion;
    public GameObject smokeEffect;
    public GameObject burnDamage;
    public GameObject pCam;
    public GameObject barricade;
    public GameObject pLight;
    public GameObject smoke;


    public AudioSource explosionFX;
    public AudioSource fallingFX;
   

    // Use this for initialization
    void Start ()
    {
        explosion.SetActive(false);

        explosionFX.GetComponent<AudioSource>();

        fallingFX.GetComponent<AudioSource>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void BigExplosion()
    {
        //play explosion and disable smoke if not already done
        explosion.SetActive(true);
        smokeEffect.SetActive(false);
        barricade.SetActive(false);
        flames.Stop();

        //stop damaging player
        this.GetComponent<ParticleDamage>().isDamaging = false;
        this.GetComponentInChildren<ParticleDamage>().isDamaging = false;
        this.GetComponent<ParticleDamage>().damageAmount = 0;

        burnDamage.GetComponent<ParticleDamage>().isDamaging = false;
        burnDamage.GetComponent<ParticleDamage>().damageAmount = 0;

        
       

        //shake first person camera
        pCam.GetComponent<CameraShake>().shake = true;

        //play audio fx
        explosionFX.Play();

        StartCoroutine(Countdown(.5f));
        fallingFX.Play();

        Countdown(5);
        pLight.SetActive(false);

        smoke.SetActive(true);
        StartCoroutine(Countdown(5));
        //smoke.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Gas Tank")
        {
            StartCoroutine(ExplodeCountdown());
            Destroy(other);
        }
    }

    IEnumerator ExplodeCountdown()
    {
        yield return new WaitForSeconds(3f);
        BigExplosion();
    }

    IEnumerator Countdown(float sec)
    {
        yield return new WaitForSeconds(sec);
    }

    private ParticleSystem _CachedFlames;
    public bool includeChildren = true;
    ParticleSystem flames
    {
        get
        {
            if (_CachedFlames == null)
                _CachedFlames = GetComponent<ParticleSystem>();
            return _CachedFlames;
        }
    }
}
