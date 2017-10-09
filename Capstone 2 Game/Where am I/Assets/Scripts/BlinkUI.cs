using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
Code originally found:
http://answers.unity3d.com/questions/1112861/how-can-i-make-a-ui-image-blink-on-and-off.html
 */


public class BlinkUI : MonoBehaviour {

	public Image imageToBlink;

	public float blinkInterval = 1f;
	public float delayStart;

	public bool currentState = true;
	bool isBlinking = false; 

	// Use this for initialization
	void Start () 
	{
		imageToBlink.enabled = true;
		StartBlink();
		
	}

	public void StartBlink()
	{
		if(isBlinking == true) return;

		if(imageToBlink != null)
		{
			isBlinking = true;
			InvokeRepeating("ToggleState", delayStart, blinkInterval);
		}
	}

	public void StopBlink()
	{
		
	}

	public void ToggleState()
	{
		imageToBlink.enabled = !imageToBlink.enabled;
	}
	
}
