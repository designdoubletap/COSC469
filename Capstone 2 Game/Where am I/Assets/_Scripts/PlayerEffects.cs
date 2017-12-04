﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
//using Assets.SwimmingSystem.Scripts;

public class PlayerEffects : MonoBehaviour {

	public GameObject audioManager;
    public bool reset = false;
    public float cooldownTime;
    public Canvas sightCanvas;
    public Canvas soundCanvas;
    public Canvas weirdCanvas;
    //public Canvas toolCanvas;
    public int typeOfMushroom;
    public float pMass;
    public bool hasTool;

    public int numVentClosed;
    public Canvas endscreen;
    public Canvas pauseMenu;

	// Use this for initialization
	void Start () 
	{
        pMass = gameObject.GetComponent<Rigidbody>().mass;

    }
	
	// Update is called once per frame
	void Update () 
	{
        //win screen
        if(numVentClosed == 4)
        {
            endscreen.gameObject.SetActive(true);
            pauseMenu.gameObject.SetActive(false);
            Time.timeScale = 0;
            audioManager.GetComponent<AudioManager>().PauseAll();
            Cursor.lockState = CursorLockMode.Confined;
           GetComponent<FirstPersonController>().enabled = false;
            GetComponent<HealthBar>().isDone = true;
            Cursor.visible = true;
            Debug.Log("Game over");
        }
       // Debug.Log("Vents Closed: " + numVentClosed);
	}

	public void Neutral()
	{
        if (reset == true)
        {
            StopAllCoroutines();
            Debug.Log("Stopping and resetting");
        }
        //sight mushroom
        if (typeOfMushroom == 1)
        {
            StartCoroutine(SightCooldown());
            sightCanvas.gameObject.SetActive(true);
            soundCanvas.gameObject.SetActive(false);
            this.gameObject.GetComponent<Swim>().canSwim = false;
            pMass = 175;
        }
        
        //sound mushroom
        else if(typeOfMushroom == 2)
        {
            StartCoroutine(SoundCooldown());
            soundCanvas.gameObject.SetActive(true);
            sightCanvas.gameObject.SetActive(false);
            this.gameObject.GetComponent<Swim>().canSwim = true;
            //this.gameObject.GetComponent<Swu>
        }
        
        //weird mushroom
        else if(typeOfMushroom == 3)
        {
            StartCoroutine(WeirdCooldown());
            weirdCanvas.gameObject.SetActive(true);
            sightCanvas.gameObject.SetActive(false);
            soundCanvas.gameObject.SetActive(false);
            this.gameObject.GetComponent<Swim>().canSwim = true;
        }
        

	}

	IEnumerator SightCooldown()
	{

        //yield return new WaitForSeconds(cooldownTime / 2);
        //sightCanvas.GetComponent<BlinkUI>().StartBlink();

        yield return new WaitForSeconds(cooldownTime);

		Camera.main.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().downsample = 2;
		Camera.main.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().blurSize = 2f;
		Camera.main.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().blurIterations = 2;
       pMass = 50;

        audioManager.GetComponent<AudioManager>().ResetVolume();
        sightCanvas.gameObject.SetActive(false);
        //sightCanvas.GetComponent<BlinkUI>().StopBlink(); 
	}

    IEnumerator SoundCooldown()
    {
        yield return new WaitForSeconds(cooldownTime);

        Camera.main.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().downsample = 2;
        Camera.main.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().blurSize = 2f;
        Camera.main.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().blurIterations = 2;
        audioManager.GetComponent<AudioManager>().ResetVolume();
        this.gameObject.GetComponent<Swim>().canSwim = false;
        soundCanvas.gameObject.SetActive(false);
    }

    IEnumerator WeirdCooldown()
    {
        yield return new WaitForSeconds(cooldownTime + 30f);

        Camera.main.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().downsample = 2;
        Camera.main.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().blurSize = 2f;
        Camera.main.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().blurIterations = 2;
        Camera.main.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().blurShader = Shader.Find("Hidden/ScreenSpaceAmbientObscurance");
        audioManager.GetComponent<AudioManager>().ResetVolume();
        this.gameObject.GetComponent<Swim>().canSwim = false;
        weirdCanvas.gameObject.SetActive(false);
    }

 
}

