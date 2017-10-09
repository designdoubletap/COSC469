using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using TMPro;

public class HandleTextFile : MonoBehaviour 
{

    public float delay = .1f;
    public string fText;
    private string currentText;

    public List<string> textLines;

    //TextAsset textFile = (TextAsset)Resources.Load(("voiceDialog1"),typeof(TextAsset));
    // string textString = HandleTextFile.text;

    void Start()
    {
        //ReadFile(textFile);
       
        StartCoroutine(ShowText());
    }


	public void ReadFile(string filename)
	{


        var sr = File.OpenText(filename);
        textLines = sr.ReadToEnd().Split('\n').ToList();
        sr.Close();

        Debug.Log(textLines);


        /*
		using (StreamReader reader  = new StreamReader(fs, Encoding.Unicode))
		{
			content = reader.ReadToEnd();
		}
        


        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        reader.Close();
        */
    }



    IEnumerator ShowText()
    {
        for (int i = 0; i <= fText.Length; i++)
        {
            currentText = fText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            
            yield return new WaitForSeconds(delay);
        }
    }	
}
