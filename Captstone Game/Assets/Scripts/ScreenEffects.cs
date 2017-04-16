using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class ScreenEffects : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Camera.main.GetComponent<UnityStandardAssets.ImageEffects.Blur>().enabled = true;
        //Camera.main.GetComponent<UnityStandardAssets.ImageEffects.Blur>().iterations = 2;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Mushroom")
        {
            Camera.main.GetComponent<UnityStandardAssets.ImageEffects.Blur>().iterations = 10;
        }
    }
}
