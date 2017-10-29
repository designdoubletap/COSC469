using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchBehavior : MonoBehaviour {

    public Transform pCam;
    float camW;
    float camH;

    GameObject torch;
    Vector3 snap = new Vector3();
    
    // Use this for initialization
    void Start ()
    {
        torch = this.gameObject;
        pCam.GetComponent<Camera>();
        camW = pCam.GetComponent<Camera>().pixelWidth;
        camH = pCam.GetComponent<Camera>().pixelHeight;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(torch.GetComponent<Pickup>().pickedUp == true)
        {
            Debug.Log("Torch is picked up");
            //torch.transform.position = new Vector3(camW, camH / 2);
           
        }

        if(torch.GetComponent<Pickup>().pickedUp == false)
        {
            torch.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
	}

    ParticleSystem flames
    {
        get
        {
            if (_CachedSystem == null)
                _CachedSystem = GetComponent<ParticleSystem>();
            return _CachedSystem;
        }
    }

    private ParticleSystem _CachedSystem;
    public bool includeChildren = true;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Water")
        {
            flames.Stop();
            Debug.Log("Touching water");
            
        }
        Debug.Log("Torch touching something");
    }
}
