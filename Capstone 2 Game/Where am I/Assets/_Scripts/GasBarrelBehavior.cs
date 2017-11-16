using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasBarrelBehavior : MonoBehaviour {

    public Transform player;
    public Transform pCam;

    public GameObject leak;
    

    float force = 2f;

    public float objMass;


    bool inRange = false;
    bool pickedUp = false;
    bool wallTouch = false;
    
	// Use this for initialization
	void Start ()
    {
        this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
	}
	
	// Update is called once per frame
	void Update ()
    {
        objMass = this.GetComponent<Rigidbody>().mass;

        float playerRange = Vector3.Distance(gameObject.transform.position, player.position);
        float playerMass = player.GetComponent<Rigidbody>().mass;
        //is player in range?
        if (playerRange <= 1f)
        {
            inRange = true;
        }
        else { inRange = false; }

        //player in range and is pressing interact button
        if (inRange == true && Input.GetButtonDown("Interact"))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = pCam;
            pickedUp = true;
            GetComponent<Rigidbody>().useGravity = true;
            leak.SetActive(false);
        }

        if (pickedUp == true)
        {
            this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;


            //drop object if player touches wall
            if (wallTouch == true)
            {
                GetComponent<Rigidbody>().isKinematic = false;

                transform.parent = null;
                pickedUp = false;
                wallTouch = false;

            }

            //throw
            if (Input.GetMouseButtonDown(0) == true)
            {
                GetComponent<Rigidbody>().isKinematic = false;

                transform.parent = null;
                pickedUp = false;
                GetComponent<Rigidbody>().AddForce(pCam.forward * force);


            }
            //drop
            else if (Input.GetMouseButton(1))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                pickedUp = false;

            }
        }


    }

    
}

