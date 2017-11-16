using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
Code originally found:
http://answers.unity3d.com/questions/1112861/how-can-i-make-a-ui-image-blink-on-and-off.html
 */


public class BlinkUI : MonoBehaviour {

	//public Image imageToBlink;
    public Canvas imagesToBlink;
    public Transform player;

	public float blinkInterval = 1f;
    float delayStart;

	public bool currentState = true;
	bool isBlinking = false; 

	// Use this for initialization
	void Start () 
	{
		imagesToBlink.GetComponent<Canvas>().enabled = true;
		StartBlink();

        delayStart = player.GetComponent<PlayerEffects>().cooldownTime / 2;
	}

	public void StartBlink()
	{
        imagesToBlink.gameObject.SetActive(true);
		if(isBlinking == true) return;

		if(imagesToBlink != null)
		{
			isBlinking = true;
			InvokeRepeating("ToggleState",delayStart, blinkInterval);
		}
	}

	public void StopBlink()
	{
        imagesToBlink.GetComponent<Canvas>().enabled = false;
        imagesToBlink.gameObject.SetActive(false);
	}

	public void ToggleState()
	{
		imagesToBlink.GetComponent<Canvas>().enabled = !imagesToBlink.GetComponent<Canvas>().enabled;
	}
	
}
