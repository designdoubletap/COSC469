using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Detect : MonoBehaviour {

    public Transform pCam;
   
    void OnTriggerStay(Collider other)
	{
		if(other.tag == "Mushroom")
			{
            GetComponent<Rigidbody>().AddForce(pCam.forward * 175);
                
			}	
	}

    
}
