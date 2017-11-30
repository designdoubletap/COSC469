using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerToggle : MonoBehaviour {

    public float waitTime;
    public float repeatRate;
    public float offsetTime;
    public GameObject flameThrower;

    public GameObject pCam;

    //public float delayStart;

	// Use this for initialization
	void Start ()
    {
        InvokeRepeating("ToggleFlame", waitTime, repeatRate);
        //StartCoroutine(Toggle(waitTime, offsetTime));
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Toggle(waitTime, offsetTime);
    }

    IEnumerator Toggle(float oT)
    {
        //yield return new WaitForSeconds(wT);

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

        if(flameThrower.activeInHierarchy== true)
        {
            other.GetComponent<HealthBar>().TakeDamage(100);
            Debug.Log("You died");
        }
        
    }
}
