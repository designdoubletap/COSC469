using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupNeutral : MonoBehaviour {

    public Transform player;
    public Transform pCam;

    float playerMass;
    public float force = 10;

    bool inRange = false;
    bool pickedUp = false;
    bool wallTouch = false;

    public AudioClip[] soundFX;
    private AudioSource soundSource;
    private AudioSource eatSoundSource;

    public Renderer rend;
    //public Renderer blurRend;

    // Use this for initialization
    void Start()
    {

        //get audio source
        soundSource = GetComponent<AudioSource>();

        //eat audio 
        eatSoundSource = GetComponent<AudioSource>();

        //render gameobject
        rend = GetComponent<Renderer>();
        rend.enabled = true;

        //blurRend = GetComponent<Camera.main.Unit>

        GetComponent<Rigidbody>().useGravity = false;

    }

    // Update is called once per frame
    void Update()
    {


        float playerRange = Vector3.Distance(gameObject.transform.position, player.position);

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
                dropSound();
            }

            //throw
            if (Input.GetMouseButtonDown(0) == true)
            {
                GetComponent<Rigidbody>().isKinematic = false;

                transform.parent = null;
                pickedUp = false;
                GetComponent<Rigidbody>().AddForce(pCam.forward * force);
                dropSound();

            }
            //drop
            else if (Input.GetMouseButton(1))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                pickedUp = false;
                dropSound();
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                eatSound();
                rend.enabled = false;
                //Destroy(this.gameObject);
                Debug.Log("Mushroom eaten");

                playerMass = 100;

                player.GetComponent<Rigidbody>().mass = playerMass;

                Destroy(this.gameObject);


                Camera.main.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().downsample = 1;
                Camera.main.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().blurSize = 2.05f;

            }
        }
    }

    void eatSound()
    {
        if (soundSource.isPlaying)
        {
            return;
        }

        soundSource.clip = soundFX[1];
        soundSource.Play();
    }

    void dropSound()
    {
        if (soundSource.isPlaying)
        {
            return;
        }

        soundSource.clip = soundFX[0];
        soundSource.Play();
    }

    void OnTriggerEnter()
    {
        if (pickedUp == true)
        {
            wallTouch = true;



        }
    }
}
