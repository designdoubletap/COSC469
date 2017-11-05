using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenButtonManager : MonoBehaviour {

    public GameObject proceedGO;
    public Button proceed;

	// Use this for initialization
	

    void Start()
    {
        proceed.onClick.AddListener(delegate { Proceed(); });

        proceedGO.SetActive(false);

        StartCoroutine(Wait());

        
        
    }

    public void Proceed()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(15f);
        proceedGO.SetActive(true);
    }
	
	
}
