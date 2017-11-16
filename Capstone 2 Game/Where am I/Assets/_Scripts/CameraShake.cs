using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    public float power = .7f;
    public float duration = 1f;
    public float slowDown = 1f;
    public bool shake;
    public Transform pCamera;

    private Vector3 startPos;
    private float initialDuration;

	// Use this for initialization
	void Start ()
    {
        pCamera = Camera.main.transform;
        startPos = pCamera.localPosition;
        initialDuration = duration;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(shake == true)
        {
            if(duration > 0)
            {
                pCamera.localPosition = startPos + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowDown;
            }
            else
            {
                shake = false;
                duration = initialDuration;
                pCamera.localPosition = startPos;
            }
        }
	}
}
