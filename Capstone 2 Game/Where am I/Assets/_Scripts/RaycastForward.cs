using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class RaycastForward : MonoBehaviour {

    //public Text hudText;
    public TextMeshProUGUI tmpHud;
    public Image hand;
    public Image drop;
    public Image pickup;
    
    public Transform player;
    public float playerMass;
    float objMass;
	
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
                        hand.gameObject.SetActive(false);
                        pickup.gameObject.SetActive(false);
                    }
                    if(playerMass >= objMass)
                    {
                        tmpHud.text = msg;
                    }

                    if (msg.Equals("Broken Vent") && player.GetComponent<PlayerEffects>().hasTool == true)
                    {
                        tmpHud.text = msg + "\nPress E to Fix";
                    }
                    else if (msg.Equals("Broken Vent"))
                        tmpHud.text = msg;

                    
                }
                else
                {
                    //Debug.Log("Hitting nothing");
                    tmpHud.text = "";
                    hand.gameObject.SetActive(false);
                    pickup.gameObject.SetActive(false);
                }
            }        
			
		}
        else { tmpHud.text = ""; }

	}


    IEnumerator Pause(float sec)
    {
        yield return new WaitForSeconds(sec);
    }
}
