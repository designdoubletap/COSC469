using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class RaycastForward : MonoBehaviour {

    //public Text hudText;
    public TextMeshProUGUI tmpHud;
    public TextMeshProUGUI voiceHud;

    public GameObject smoke;


    public Transform player;
    public float playerMass;
    float objMass;

    public float fire;
    
    

    bool firstHit = true;
    string voiceDialog1 = "Hello!\nI am your friendly neighborhood voice in your head.\nNo, no, you're not going crazy. You are perfectly sane and healthy.\nExcept for the gas. Don't you smell that? ";
    string dialog;
    string dHolder;
    float waitTime;

	// Use this for initialization
	void Start () 
	{

       //StartCoroutine(DialogQ());
        
	}
	
	// Update is called once per frame
	void Update () 
	{
        //get player current mass
        playerMass = player.GetComponent<Rigidbody>().mass;
        

		RaycastHit hit;
		float distance; 

		Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;	
		Debug.DrawRay(transform.position,forward,Color.blue);

        //Dialogue();
        
		if(Physics.Raycast(transform.position, (forward),out hit))
		{
			distance = hit.distance;
            string msg = hit.collider.gameObject.tag;
            if (distance <= 5 )
            {
                /*
                if (EventSystem.current.IsPointerOverGameObject())
                {
                    tmpHud.SetText(msg);
                }*/
                
                //check layer
                if(hit.collider.gameObject.layer == 8)
                {
                    //display tag to player
                    
                    objMass = hit.collider.gameObject.GetComponent<Rigidbody>().mass;

                    if(playerMass < objMass)
                    {
                        msg = msg + "\nHeavy!";
                        StartCoroutine(ShowHUD(msg));
                        //tmpHud.text = msg;
                        
                    }
                    else if(playerMass >= objMass)
                    {
                        StartCoroutine(ShowHUD(msg));
                        //tmpHud.text = msg;
                    }                   
                }
                
            }        
			
		}
        else { tmpHud.text = ""; }

	}

    

    IEnumerator ShowHUD(string message)
    {
        tmpHud.text = message;
        yield return new WaitForSecondsRealtime(.5f);
        tmpHud.text = "";
        

    }

    public void  MushroomTut()
    {
        StartCoroutine(Pause(30));
        voiceHud.text = "Is that a mushroom? It looks kinda interesting..";
        StartCoroutine(Pause(3));
        voiceHud.SetText("It smells pretty good...");
        StartCoroutine(Pause(2));
        voiceHud.SetText("Hey, maybe you should eat it. What's the worst that could happen? Plus maybe you'll gain superpowers like being able to shoot fireballs.");

    }

    IEnumerator TutorialHUD()
    {
        yield return new WaitForSecondsRealtime(5);
        voiceHud.SetText("Pick it up. Press E");
    }

 

    IEnumerator DialogQ()
    {
        yield return new WaitForSecondsRealtime(3);
        voiceHud.SetText("Something is not right here...");
        Pause(3);
       
    }

 

    

    public void Dialogue()
    {
        voiceHud.SetText("Is that fire? Move forwad I want to get a better look.");
        StartCoroutine(Pause(3));
        voiceHud.SetText("Man, the heat is intense. Don't go any closer or you'll get burnt. See that white bar down there? That's your health");
        StartCoroutine(Pause(5));
        voiceHud.SetText("Maybe there's something here that can help");
        StartCoroutine(Pause(5));
        voiceHud.SetText("");
        Pause(10);
        voiceHud.SetText("All I see are a bunch of old boxes, a leaky vent and a mushroom.");
        Pause(5);
        voiceHud.SetText("Hey! Maybe we could add those things together. I remember those old games where mushrooms gave players powers and made them grow really strong and stuff. ");
    }

    IEnumerator Pause(float sec)
    {
        yield return new WaitForSeconds(sec);
    }
}
