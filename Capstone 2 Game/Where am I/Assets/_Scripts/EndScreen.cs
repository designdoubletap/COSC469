using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour {

    public int ventNum;
    public int closed;
    public GameObject overlay;
    public bool spawnV;
    public bool waterFallV;
    public bool flameV;
    public bool basementV;

    void Start()
    {
        overlay.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(closed == 4)
        {
            overlay.SetActive(true);
            Debug.Log("Win");
        }

        if(spawnV == true && waterFallV == true && flameV == true && basementV == true)
        {
            overlay.SetActive(true);
            Debug.Log("Win 2");
        }
        //Debug.Log(closed);
	}
}
