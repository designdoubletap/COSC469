using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMushroom : MonoBehaviour {

    GameObject mushroom;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //mushroom = this.GetComponentInChildren<GameObject>().
        if(this.GetComponentInChildren<Pickup>().eaten == true)
        {
            //Destroy(GameObject.find)
        }
	}
}
