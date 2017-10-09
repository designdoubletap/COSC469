using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour {

    public bool isDamaging = true;
    public float damageAmount;

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            //player takes damage as long as they remain in damage zone

            damageAmount = GetComponentInChildren<ParticleDamage>().damageAmount;
            

            other.SendMessage((isDamaging) ? "TakeDamage" : "TakeDamage", Time.deltaTime * damageAmount);

            
        }
    }

   
}
