using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehvior : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private ParticleSystem _CachedSystem;
	public bool includeChildren = true;
	ParticleSystem flames
	{
		get
		{
			if (_CachedSystem == null)
				_CachedSystem = GetComponent<ParticleSystem>();
			return _CachedSystem;
		}
	}

	public void StopFire()
	{
		flames.Stop ();
	}

	public void StartFire()
	{
		flames.Play ();
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" || other.tag == "MainCamera")
		{
			Debug.Log ("Touching fire");
			other.GetComponentInChildren<FireBehvior> ().StartFire ();
		}
	}


}
