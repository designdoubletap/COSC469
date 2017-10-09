using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObjects : MonoBehaviour {

    public Transform player;
    public Transform pCam;

    public AudioSource soundFx;

    public float playerMass;
    public float objMass;

    bool inRange = false;
    bool pickedUp = false;
    bool wallTouch = false;

    // Use this for initialization
    void Start () {

        soundFx = GetComponent<AudioSource>();
	}

    // Update is called once per frame
    void Update()
    {

        playerMass = player.GetComponent<Rigidbody>().mass;
        objMass = this.GetComponent<Rigidbody>().mass;

        float playerRange = Vector3.Distance(gameObject.transform.position, player.position);

        //is player in range?
        if (playerRange <= 1f)
        {
            inRange = true;
        }
        else { inRange = false; }

        //player in range and is pressing interact button
        if (inRange == true && Input.GetButtonDown("Interact") && (playerMass > objMass))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = pCam;
            pickedUp = true;
        }

        if (pickedUp == true)
        {

            GetComponent<Rigidbody>().useGravity = true;

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
                GetComponent<Rigidbody>().AddForce(pCam.forward * playerMass);


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
