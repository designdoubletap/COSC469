﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehavior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Player" || other.tag == "MainCamera")
		{
			Debug.Log ("Touching water");
			other.GetComponentInChildren<FireBehvior> ().StopFire ();
		}
	}
}
