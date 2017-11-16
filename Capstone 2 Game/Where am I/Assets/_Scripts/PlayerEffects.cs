using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour {

	public GameObject audioManager;
    public bool reset = false;

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
        if(reset == true)
        {
            StopAllCoroutines();
        }

        //StopCoroutine(Cooldown());
        StartCoroutine (Cooldown ());

	}

	IEnumerator Cooldown()
	{
		yield return new WaitForSeconds(10f);

		Camera.main.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().downsample = 2;
		Camera.main.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().blurSize = 2f;
		Camera.main.GetComponent<UnityStandardAssets.ImageEffects.BlurOptimized>().blurIterations = 2;
		audioManager.GetComponent<AudioManager>().ResetVolume();  
	}
}
