using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterBehavior : MonoBehaviour {

    //pubbli

    public bool deepWater;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player" || other.tag == "MainCamera")
		{
			//Debug.Log ("Touching water");
			other.GetComponentInChildren<FireBehvior> ().StopFire ();
            
            if(deepWater == true)
            {
                
            }
		}

        
	}
}
