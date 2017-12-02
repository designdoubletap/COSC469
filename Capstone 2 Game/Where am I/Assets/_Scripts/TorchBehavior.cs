using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchBehavior : MonoBehaviour {


    GameObject torch;
    GameObject fire;
   
    
    
    // Use this for initialization
    void Start ()
    {
        torch = this.gameObject;
        fire = torch.transform.FindChild("Fire").gameObject;
        

	}
	
	// Update is called once per frame
	void Update ()
    {
		//when torch is dropped it will land correctly
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
            //flames.Stop();
            fire.GetComponent<FireBehvior>().StopFire();
            Debug.Log("Touching water");
            
        }
        Debug.Log("Torch touching something");
    }
}
