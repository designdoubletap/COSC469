using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour {

    public Transform moistShrrom;
    bool spawnNew;

	// Use this for initialization
	void Start ()
    {
       
	}
	
	// Update is called once per frame
	void Update ()
    {
        

        for (int i = 0; i < 1; i++)
        {
            if (spawnNew == true)
            {
                Instantiate(moistShrrom, this.GetComponent<Transform>());
            }
            else
                spawnNew = false;
        }
	}

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Moist Mushroom")
        {
            spawnNew = false;
        }
        else
            spawnNew = true;
    }
}
