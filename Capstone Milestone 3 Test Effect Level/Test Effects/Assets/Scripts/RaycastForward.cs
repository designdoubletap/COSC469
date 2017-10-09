using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RaycastForward : MonoBehaviour {

    public Text hudText;
    public TextMeshProUGUI tmpHud;
    public TextMeshProUGUI voiceHud;

    //handle blinking HUD
    public BlinkUI uiBlink;
    public Image mushInventory;
    
    

    bool firstHit = true;
    string voiceDialog1 = "Hello!\nI am your friendly neighborhood voice in your head.\nNo, no, you're not going crazy. You are perfectly sane and healthy.\nExcept for the gas. Don't you smell that? ";

	// Use this for initialization
	void Start () 
	{

        mushInventory.GetComponent<BlinkUI>();
	}
	
	// Update is called once per frame
	void Update () 
	{

		RaycastHit hit;
		float distance; 

		Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;	
		Debug.DrawRay(transform.position,forward,Color.blue);

        
		if(Physics.Raycast(transform.position, (forward),out hit))
		{
			distance = hit.distance;
            if(distance <= 10 )
            {
                //Game Elements layer
                if(hit.collider.gameObject.layer == 8)
                {
                    //display tag to player
                    string msg = hit.collider.gameObject.tag;
                    StartCoroutine(ShowHUD(msg));

                    //display voice dialog
                    StartCoroutine(Dialog(firstHit, mushInventory));
                }
               
            }
			
		}
        

        /*
        if(Physics.Raycast(transform.position, forward, 2))
        {

            print("There is something in front of the object");
        }
        */

	}

    IEnumerator ShowHUD(string message)
    {
        tmpHud.text = message;
        yield return new WaitForSeconds(1f);
        tmpHud.text = "";

    }

    IEnumerator Dialog(bool firstTime, Image mushI)
    {
        yield return new WaitForSeconds(10);
        voiceHud.text = "Hello! I am here to help";

        if(firstHit == true)
        {
            voiceHud.text = "This is a mushroom. You can see what is active here";
            
            

        }

        yield return new WaitForSeconds(20);
        voiceHud.text = "Waiting for 20 secs";




    }

    
}
