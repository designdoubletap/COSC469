using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Detect : MonoBehaviour {

    bool promptKey = false;
    public Text interactPrompt;
	// Use this for initialization
	void Start () {

        interactPrompt.text = "Press E to Interact";
	}
	
	// Update is called once per frame
	void Update () {
        
       if (Input.GetKeyDown(KeyCode.E))
        {
            promptKey = true;
        }
	
	}

    //stops particle system
    ParticleSystem sparks
    {
        get
        {
            if (_CachedSparks == null)
                _CachedSparks = GetComponent<ParticleSystem>();
            return _CachedSparks;
        }
    }

    private ParticleSystem _CachedSparks;
    public bool includeChildren = true;


    void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player" && promptKey == true)
			{
                
                sparks.Stop(includeChildren);
                
                
			}	
	}

    
}
