using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

    public GameObject explosion;
    public GameObject smokeEffect;
    public GameObject burnDamage;
    public GameObject pCam;
   

    // Use this for initialization
    void Start ()
    {
        explosion.SetActive(false);
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    /*
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Wooden Crate")
        {
            //play explosion and disable smoke if not already done
            explosion.SetActive(true);
            smokeEffect.SetActive(false);
            this.GetComponent<ParticleDamage>().isDamaging = false;
            this.GetComponentInChildren<ParticleDamage>().isDamaging = false;
            burnDamage.GetComponent<ParticleDamage>().isDamaging = false;
            //burnDamage.GetComponent<TriggerDamage>().damageAmount = 0;
            burnDamage.GetComponent<ParticleDamage>().damageAmount = 0;


           
            Debug.Log("Huuurrrrrtty");

            //shake first person camera
            player.GetComponentInChildren<CameraShake>().shake = true;
        }
    }
    */

    public void BigExplosion()
    {
        //play explosion and disable smoke if not already done
        explosion.SetActive(true);
        smokeEffect.SetActive(false);
        this.GetComponent<ParticleDamage>().isDamaging = false;
        this.GetComponentInChildren<ParticleDamage>().isDamaging = false;
        burnDamage.GetComponent<ParticleDamage>().isDamaging = false;
        burnDamage.GetComponent<ParticleDamage>().damageAmount = 0;

        this.GetComponent<GameObject>().SetActive(false);

        //shake first person camera
        pCam.GetComponent<CameraShake>().shake = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Gas Barrel")
        {
            StartCoroutine(ExplodeCountdown());
        }
    }

    IEnumerator ExplodeCountdown()
    {
        yield return new WaitForSeconds(3f);
        BigExplosion();
    }
}
