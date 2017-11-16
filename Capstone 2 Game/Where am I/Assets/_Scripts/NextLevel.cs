using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

    public GameObject barricade;

	void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && barricade.activeInHierarchy == false)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
