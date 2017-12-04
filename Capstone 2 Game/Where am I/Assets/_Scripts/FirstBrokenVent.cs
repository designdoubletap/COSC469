using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FirstBrokenVent : MonoBehaviour {

    public GameObject msg;
    bool activate = true;

	// Use this for initialization
	void Start ()
    {
        msg.SetActive(false);
	}
	
	void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player"&& activate == true)
        {
            msg.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(WaitToClear());
        }
        activate = false;
    }

    IEnumerator WaitToClear()
    {
        yield return new WaitForSeconds(3f);
        msg.SetActive(false);
    }


}
