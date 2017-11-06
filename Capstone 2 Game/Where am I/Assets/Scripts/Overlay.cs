using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class Overlay : MonoBehaviour {

    public Transform overlayCanvas;
    public Transform optionsCanvas;
    public bool showMore;
    public Transform tipsCanvas;
    public Transform tip;
    public Transform tip2;
    public Transform tipBack;
    public Transform helpShowMore;
    public Transform hudCanvas;
    public Transform deathCanvas;
    public GameObject audioManager;

    public Transform player;

	// Use this for initialization
	void Start ()
    {
        overlayCanvas.gameObject.SetActive(false);
        optionsCanvas.gameObject.SetActive(false);
        tipsCanvas.gameObject.SetActive(false);
        deathCanvas.gameObject.SetActive(false);

        if(showMore == true)
        {
            tip.gameObject.SetActive(true);
            //tipBack.gameObject.SetActive(true);
            tip2.gameObject.SetActive(false);
            helpShowMore.gameObject.SetActive(false);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();            
        }

        
	}

    public void Pause()
    {
        if (overlayCanvas.gameObject.activeInHierarchy == false && deathCanvas.gameObject.activeInHierarchy == false)
        {
            overlayCanvas.gameObject.SetActive(true);
            optionsCanvas.gameObject.SetActive(false);
            hudCanvas.gameObject.SetActive(false);

            //pause gameworld
            Time.timeScale = 0;
            //pause audio
            audioManager.GetComponent<AudioManager>().PauseAll();

            //pause first person controller
            player.GetComponent<FirstPersonController>().enabled = false;

            //show mouse cursor
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }

    public void Resume()
    {
        overlayCanvas.gameObject.SetActive(false);
        hudCanvas.gameObject.SetActive(true);

        //resume gameworld
        Time.timeScale = 1;

        //unpause audio
        audioManager.GetComponent<AudioManager>().ResumeAll();

        //resume first person controller
        player.GetComponent<FirstPersonController>().enabled = true;

        //hide mouse cursor
        Cursor.visible = false;
    }

    public void Help()
    {
        tipsCanvas.gameObject.SetActive(true);
        tipBack.gameObject.SetActive(true);
    }

    public void NextHelp()
    {
        tipsCanvas.gameObject.SetActive(true);
        tipBack.gameObject.SetActive(true);

        if (tip.gameObject.activeInHierarchy == true)
        {
            tip2.gameObject.SetActive(true);
            tip.gameObject.SetActive(false);
        }
        else if (tip2.gameObject.activeInHierarchy == true)
        {
            tip2.gameObject.SetActive(false);
            tip.gameObject.SetActive(true);
        }
    }

    public void Options()
    {
        optionsCanvas.gameObject.SetActive(true);
        overlayCanvas.gameObject.SetActive(false);
    }

    public void Back()
    {
        optionsCanvas.gameObject.SetActive(false);
        tipsCanvas.gameObject.SetActive(false);
        overlayCanvas.gameObject.SetActive(true);
    }

    public void Restart()
    {
       
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
        audioManager.GetComponent<AudioManager>().ResumeAll();
    }

    public void Death()
    {
        deathCanvas.gameObject.SetActive(true);
        overlayCanvas.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Time.timeScale = 0;
        audioManager.GetComponent<AudioManager>().PauseAll();
        player.GetComponent<FirstPersonController>().enabled = false;
    }

    public void Quit()
    {
        Application.Quit();
    }

}
