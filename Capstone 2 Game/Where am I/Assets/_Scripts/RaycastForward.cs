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
	void FixedUpdate () 
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
            if (distance <= 7 )
            {
                

                if (hit.collider.gameObject.layer == 8)
                {
                    objMass = hit.collider.gameObject.GetComponent<Rigidbody>().mass;

                    if(playerMass < objMass)
                    {
                        msg = msg + "\nHeavy!";
                        tmpHud.text = msg;
                    }
                    if(playerMass >= objMass)
                    {
                        tmpHud.text = msg;
                    }

                    
                }
                else
                {
                    //Debug.Log("Hitting nothing");
                    tmpHud.text = "";
                }
            }        
			
		}
        else { tmpHud.text = ""; }

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

    IEnumerator Pause(float sec)
    {
        yield return new WaitForSeconds(sec);
    }
}
