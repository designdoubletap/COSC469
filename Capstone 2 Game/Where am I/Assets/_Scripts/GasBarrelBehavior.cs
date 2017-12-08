using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GasBarrelBehavior : MonoBehaviour {

    public Transform player;
    public Transform pCam;

    public GameObject leak;

    Image handUI;
    Image dropUI;
    Image pickupUI;

    float force = 2f;

    public float objMass;


    bool inRange = false;
    bool pickedUp = false;
    bool wallTouch = false;
    
	// Use this for initialization
	void Start ()
    {
        this.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

        handUI = pCam.GetComponent<RaycastForward>().hand;
        dropUI = pCam.GetComponent<RaycastForward>().drop;
        pickupUI = pCam.GetComponent<RaycastForward>().pickup;

        handUI.gameObject.SetActive(false);
        dropUI.gameObject.SetActive(false);
        pickupUI.gameObject.SetActive(false);
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
            handUI.gameObject.SetActive(true);
            pickupUI.gameObject.SetActive(true);
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
            handUI.gameObject.SetActive(true);
            dropUI.gameObject.SetActive(true);
            pickupUI.gameObject.SetActive(false);

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

                handUI.gameObject.SetActive(false);
                dropUI.gameObject.SetActive(false);
                pickupUI.gameObject.SetActive(false);

            }
        }


    }

    
}

