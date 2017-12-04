using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour {

    public bool isDamaging = true;
    public bool isWater;
    public float damageAmount;

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            //player takes damage as long as they remain in damage zone

            damageAmount = GetComponentInChildren<ParticleDamage>().damageAmount;
            

            other.SendMessage((isDamaging) ? "TakeDamage" : "TakeDamage", Time.deltaTime * damageAmount);

            
        }
        //only damages the player when the actual camera is submereged 
        else if (isWater == true && other.tag=="Main Camera")
        {

            if(other.GetComponentInParent<Swim>().canSwim == true)
            {
                isDamaging = false;
                GetComponentInChildren<ParticleDamage>().isDamaging = false;
            }
            else if(other.GetComponentInParent<Swim>().canSwim == false)
                damageAmount = GetComponentInChildren<ParticleDamage>().damageAmount;
            

            other.SendMessage((isDamaging) ? "TakeDamage" : "TakeDamage", Time.deltaTime * damageAmount);
        }
    }

   
}
