using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fading : MonoBehaviour 
{
	public Texture2D fadeOutTexture; 
	public float fadeSpeed = 0.8f;  

	private int drawDepth = -1000; 
	private float alpha = 1.0f; 
	private int fadeDir = -1; 

	void OnGUI()
	{

		alpha += fadeDir * fadeSpeed * Time.deltaTime; 

		alpha = Mathf.Clamp01 (alpha); 

		GUI.color = new Color (GUI.color.g, GUI.color.r, GUI.color.b, alpha); 
		GUI.depth = drawDepth;
		GUI.DrawTexture ( new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture); 
	}

	
	public float BeginFade (int direction)
	{
		fadeDir = direction;
		return (fadeSpeed); 
	}

	void OnLevelLoaded()
	{
		BeginFade (-1); 
	}

    void OnTriggerEnter(Collider other)
    {
       
        Scene curScene = SceneManager.GetActiveScene();

        if(curScene.name == "scene1")
        {
            SceneManager.LoadScene("scene2");
            BeginFade(-1);
        }
        else if(curScene.name == "scene2")
        {
            SceneManager.LoadScene("scene1");
            BeginFade(-1);
        }
        
    }
}
