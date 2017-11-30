using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenButtonManager : MonoBehaviour {

    public GameObject loadingGO;
    public GameObject proceedGO;
    public bool showMore;
    public Transform tipPanel;
    public Transform tip2Panel;
    public Transform tip3Panel;
    public Button proceed;

	// Use this for initialization
	

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;

        proceed.onClick.AddListener(delegate { Proceed(); });

        proceedGO.SetActive(false);
        

        StartCoroutine(Wait());

        if(showMore == true)
        {
             
            tipPanel.gameObject.SetActive(true);
            tip2Panel.gameObject.SetActive(false);
            tip3Panel.gameObject.SetActive(false);
            StartCoroutine(TransitionWait());
        }
        

        
        
    }

    public void Proceed()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //Debug.Log(SceneManager.GetActiveScene().buildIndex + 1);
    }


    IEnumerator Wait()
    {
        yield return new WaitForSeconds(7f);
        loadingGO.SetActive(false);
        proceedGO.SetActive(true);
    }

    IEnumerator TransitionWait()
    {
        yield return new WaitForSeconds(3f);
        tipPanel.gameObject.SetActive(false);
        tip2Panel.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);
        tip2Panel.gameObject.SetActive(false);
        tip3Panel.gameObject.SetActive(true);
    }

	
	
}
