using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDamage : MonoBehaviour {

    public bool isDamaging;
    public float damageAmount = 10;

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            //player takes damage as long as they remain in damage zone

            other.SendMessage((isDamaging) ? "TakeDamage" : "HealDamage", Time.deltaTime * damageAmount);
        }
    }

   
}
