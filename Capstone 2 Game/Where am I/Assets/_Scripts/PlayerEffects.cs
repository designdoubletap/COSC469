using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour {

	public GameObject audioManager;
    public bool reset = false;
    public float cooldownTime;
    public Canvas sightCanvas;
    public Canvas soundCanvas;
    public Canvas weirdCanvas;
    public int typeOfMushroom;    

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void Neutral()
	{
        if (reset == true)
            StopAllCoroutines();
        if (typeOfMushroom == 1)
        {
            StartCoroutine(SightCooldown());
            sightCanvas.gameObject.SetActive(true);
            soundCanvas.gameObject.SetActive(false);
            reset = true;
        }
        if(typeOfMushroom == 2)
        {
            StartCoroutine(SoundCooldown());
            soundCanvas.gameObject.SetActive(true);
            sightCanvas.gameObject.SetActive(false);
            reset = true;
        }
        if(typeOfMushroom == 3)
        {
            StartCoroutine(WeirdCooldown());
            weirdCanvas.gameObject.SetActive(true);
            sightCanvas.gameObject.SetActive(false);
            soundCanvas.gameObject.SetActive(false);
            reset = true;
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
        //

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
        weirdCanvas.gameObject.SetActive(false);
    }

    private void ColliderEnter(Collision other)
    {
        if(other.gameObject.tag == "Water")
        {
            Debug.Log("WATER");
        }
    }
}

