﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{


    //player information
    public Transform player;
    public Transform pCam;
    //float playerMass;
    public float objMass;

    public float force = 10;

    //Audio List
    public AudioClip[] soundFx;
    public GameObject audioManager;

    //audio for mushrooms
    private AudioSource soundSource;
    private AudioSource eatSoundSource;

    //toggles for mushrooms and objects
    public bool objectPickup;
    public bool isBox;
    public bool mushroom;
    public bool sightMushroom;
    public bool soundMushroom;
    public bool strangeMushroom;
    public bool neutralMushroom;

    //tools
    public bool isTool;
    public GameObject toolImg;

    //renderer for mushrooms
    //public Renderer rend;

    bool inRange = false;
    public bool pickedUp = false;
    public bool eaten = false;
    bool wallTouch = false;

   
    // Use this for initialization
    void Start()
    {
        if(isTool == true)
            toolImg.SetActive(false);

        GetComponent<Rigidbody>().useGravity = true;
        //get audio source
        soundSource = GetComponent<AudioSource>();
        //eat audio 
        eatSoundSource = GetComponent<AudioSource>();
        

    }

    // Update is called once per frame
    void Update()
    {
        
        objMass = this.GetComponent<Rigidbody>().mass;
        //playerMass = player.GetComponent<PlayerEffects>().pMass;


        float playerRange = Vector3.Distance(gameObject.transform.position, player.position);
        //is player in range?
        if (playerRange <= 1f)
        {
            inRange = true;
        }
        else { inRange = false; }

        //player in range and is pressing interact button
        if (inRange == true && Input.GetButtonDown("Interact") && player.GetComponent<PlayerEffects>().pMass >= objMass)
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = pCam;
            pickedUp = true;
        }

        //pickup 
        if (pickedUp == true)
        {
            if(isBox == true)
            {
                this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            }

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
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
                transform.parent = null;
                pickedUp = false;
                dropSound();
            }

            else if(isTool == true)
            {
                player.GetComponent<PlayerEffects>().hasTool = true;
                Debug.Log("Has tool");
                this.gameObject.SetActive(false);
                toolImg.SetActive(true);
            }

            //mushroom logic
            else if (mushroom == true)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {

                   // rend.enabled = false;
                    this.gameObject.SetActive(false);
                    eaten = true;
                    //resets all mushroom effects so their full cooldown can be reached
                    player.GetComponent<PlayerEffects>().reset = true;



                    if (sightMushroom == true)
                    {
                        player.gameObject.GetComponent<Rigidbody>().mass = 175;

                        Camera.main.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().downsample = 1;
                        Camera.main.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().blurSize = 0f;
                        Camera.main.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().blurIterations = 1;
                        audioManager.GetComponent<AudioManager>().LowerVolume();

                        player.GetComponent<PlayerEffects>().typeOfMushroom = 1;
                        player.GetComponent<PlayerEffects>().Neutral();
                        this.gameObject.SetActive(false);
                    }

                    if (soundMushroom == true)
                    {
                        Camera.main.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().downsample = 2;
                        Camera.main.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().blurSize = 4f;
                        Camera.main.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().blurIterations = 3;
                        audioManager.GetComponent<AudioManager>().RaiseVolume();
                        //eatSound();

                        player.GetComponent<PlayerEffects>().typeOfMushroom = 2;
                        player.GetComponent<PlayerEffects>().Neutral();
                        this.gameObject.SetActive(false);
                    }

                    if (strangeMushroom == true)
                    {
                        player.GetComponent<Rigidbody>().mass = 175;

                        Camera.main.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().downsample = 1;
                        Camera.main.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().blurSize = 0f;
                        Camera.main.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().blurIterations = 1;
                        audioManager.GetComponent<AudioManager>().RaiseVolume();

                        player.GetComponent<PlayerEffects>().typeOfMushroom = 3;
                        player.GetComponent<PlayerEffects>().Neutral();
                        this.gameObject.SetActive(false);
                    }

                    if (neutralMushroom == true)
                    {
                        player.GetComponent<PlayerEffects>().Neutral();
                        this.gameObject.SetActive(false);
                        //eatSound();
                    }

                }
                else
                    player.GetComponent<PlayerEffects>().reset = false;


            }
        }

        
    }


    IEnumerator dropSound()
    {
         yield return new WaitForSeconds(2f);
       

        soundSource.clip = soundFx[0];
        soundSource.Play();
    }

    void OnCollision(Collider other)
    {
        if (other.tag.Equals("Ground"))
        {
            if (soundSource.isPlaying)
            {
                return;
            }

            soundSource.clip = soundFx[0];
            soundSource.Play();
        }
    }

      
}
