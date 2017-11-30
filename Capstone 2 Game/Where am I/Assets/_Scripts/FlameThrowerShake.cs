using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameThrowerShake : MonoBehaviour {

    public GameObject pCam;
    public GameObject flameThrower;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ProximityShake()
    {
        pCam.GetComponent<CameraShake>().power = .05f;
        pCam.GetComponent<CameraShake>().duration = 1f;
        pCam.GetComponent<CameraShake>().slowDown = 1.39f;
        pCam.GetComponent<CameraShake>().shake = true;
    }

    void OnTriggerStay(Collider other)
    {
        if (flameThrower.activeInHierarchy == true && other.tag == "Player")
            ProximityShake();
    }
}
