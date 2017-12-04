using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerToggle : MonoBehaviour {

    public float waitTime;
    public float repeatRate;
    public float offsetTime;
    public GameObject flameThrower;

    public GameObject pCam;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("ToggleFlame", waitTime, repeatRate);

    }
	
    IEnumerator Toggle(float oT)
    {
        flameThrower.SetActive(false);

        yield return new WaitForSeconds(oT);

        flameThrower.SetActive(true);
    }

    void ToggleFlame()
    {
        StartCoroutine(Toggle(offsetTime));
    }

    void OnTriggerStay(Collider other)
    {

        if(flameThrower.activeInHierarchy== true && other.tag == "Player")
        {
            other.GetComponent<HealthBar>().TakeDamage(100);
            Debug.Log("You died");
        } 
    }
}
