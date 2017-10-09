using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

        
        
        StartCoroutine(DialogQ());
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

        
		if(Physics.Raycast(transform.position, (forward),out hit))
		{
			distance = hit.distance;
            string msg = hit.collider.gameObject.tag;
            if (distance <= 5 )
            {
                //check layer
                if(hit.collider.gameObject.layer == 8)
                {
                    //display tag to player
                    
                    objMass = hit.collider.gameObject.GetComponent<Rigidbody>().mass;

                    

                    if(playerMass < objMass)
                    {
                        msg = msg + "\nHeavy!";
                        StartCoroutine(ShowHUD(msg));
                    }
                    else if(playerMass >= objMass)
                    {
                        StartCoroutine(ShowHUD(msg));
                    }
                    
                    //tutorial
                    if (firstHit == true && msg.Equals("Mushroom"))
                    {
                        firstHit = false;
                        StartCoroutine(MHUD());
                        StopCoroutine(MHUD());
                        

                        //StartCoroutine(Wait());
                    }
                    
                    else
                    if(msg.Equals("Mushroom"))
                    {
                        StartCoroutine(Wait());

                        //StartCoroutine(TutorialHUD());
                        StartCoroutine(ShowHUD(msg));
                        
                    }
                    
                }

                if(hit.collider.gameObject.layer == 9)
                {
                    StartCoroutine(FireDialog(smoke, fire, msg));
                    //wStopCoroutine(FireDialog(smoke, fire));
                }
               
            }        
			
		}

	}

    

    IEnumerator ShowHUD(string message)
    {
        tmpHud.text = message;
        yield return new WaitForSecondsRealtime(.5f);
        tmpHud.text = "";

    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(60);
    }

    IEnumerator MHUD()
    {
        yield return new WaitForSecondsRealtime(1);
        voiceHud.text = "Is that a mushroom? It looks kinda interesting..";
        /*
        yield return new WaitForSeconds(45);
        voiceHud.text = "";
        voiceHud.text = "Pick it up.\nTip: Press E";

        yield return new WaitForSeconds(50);
        voiceHud.text = "Eat it, what's the worst that could happen?";
        */

    }

    IEnumerator TutorialHUD()
    {
        yield return new WaitForSecondsRealtime(5);
        voiceHud.SetText("Pick it up. Press E");
    }

    IEnumerator FireDialog(GameObject smke, float fireD, string msg)
    {
        yield return new WaitForSecondsRealtime(10);
        voiceHud.enabled = true;
        voiceHud.SetText("Is that fire? ");

        yield return new WaitForSecondsRealtime(3);
        smke.SetActive(true);
        //GetComponent<ParticleDamage>().damageAmount = ((fireD + .05f) * Time.deltaTime);
        //voiceHud.enabled = false;

        yield return new WaitForSecondsRealtime(5);
        //voiceHud.enabled = true;
        voiceHud.SetText("I think the fire is hurting us. See the white bar is moving.");

        yield return new WaitForSecondsRealtime(5);
        voiceHud.SetText("Maybe we should move back");

        yield return new WaitForSecondsRealtime(3);
        voiceHud.SetText("Maybe there's something here that can help");

        yield return new WaitForSecondsRealtime(30);
        voiceHud.SetText("Maybe those heavy boxes could help.");

        yield return new WaitForSecondsRealtime(35);
        voiceHud.SetText("That mushroom smells pretty good..");

        yield return new WaitForSecondsRealtime(50);
        if (msg.Equals("Mushroom"))
        {
            voiceHud.SetText("Pick it up (Press E) and eat it (Press F)");
        }

    }

    IEnumerator DialogQ()
    {
        yield return new WaitForSecondsRealtime(3);
        voiceHud.SetText("Something is not right here...");
    }

    /*
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Mushroom")
        {
            StartCoroutine(MushroomTutorial());
            Debug.Log("touch mushroom");
        }
    }

    IEnumerator MushroomTutorial()
    {
        yield return new WaitForSeconds(5);
        voiceHud.text = "Pick it up. Press E";

        yield return new WaitForSeconds(50);
        voiceHud.text = "Eat it, what's the worst that could happen?";

    }
    */
    
}
