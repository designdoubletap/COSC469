using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFade : MonoBehaviour {


    public Texture2D fadeOutTexture;
    public float fadeSpeed = 0.8f;

    private int DrawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDirection = -1; //-1: fade in; 1: fade out

    void OnGUI()
    {
        alpha += fadeDirection * fadeSpeed * Time.deltaTime;
        alpha = Mathf.Clamp01(alpha);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = DrawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }


    public float BeginFade(int direction)
    {
        fadeDirection = direction;
        return (fadeSpeed);
    }

    void SceneLoaded()
    {
        BeginFade(-1);
    }
	
}
