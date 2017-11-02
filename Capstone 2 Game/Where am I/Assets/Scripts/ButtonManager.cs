using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class ButtonManager : MonoBehaviour {

    public Toggle fullscreenT;
    public Dropdown resolutionD;
    public Dropdown qualityD;
    public Dropdown vSyncD;
    public Button applyButton;

    public Resolution[] resolutions;
    public GameSettings gameSettings;

    public void ChangeScene(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void OnFullScreenToggle()
    {
       gameSettings.fullscreen = Screen.fullScreen = fullscreenT.isOn;
    }

    public void ResolutionChange()
    {
        Screen.SetResolution(resolutions[resolutionD.value].width, resolutions[resolutionD.value].height, Screen.fullScreen);
        gameSettings.resolutionIndex = resolutionD.value;
    }

    public void QualityChange()
    {
        string[] names = QualitySettings.names;
      
        gameSettings.qualitySetting = qualityD.value;

        

        if(gameSettings.qualitySetting >= 4)
        {
            QualitySettings.SetQualityLevel(gameSettings.qualitySetting,true);
        }
        else
            QualitySettings.SetQualityLevel(gameSettings.qualitySetting,false);



    }

    public void VSyncChange()
    {
        QualitySettings.vSyncCount = gameSettings.vSync = vSyncD.value;
    }

    public void OnApplyButtonClick()
    {
        SaveSettings();
    }

    public void SaveSettings()
    {
        string jsonData = JsonUtility.ToJson(gameSettings, true);
        File.WriteAllText(Application.persistentDataPath + "/gamesettings.json", jsonData);
    }

    public void LoadSettings()
    {
        gameSettings = JsonUtility.FromJson<GameSettings>(File.ReadAllText(Application.persistentDataPath + "/gamesettings.json"));

        fullscreenT.isOn = gameSettings.fullscreen;
        resolutionD.value = gameSettings.resolutionIndex;
        qualityD.value = gameSettings.qualitySetting;
        vSyncD.value = gameSettings.vSync;
        Screen.fullScreen = gameSettings.fullscreen;

        resolutionD.RefreshShownValue();
    }

    void OnEnable()
    {
        gameSettings = new GameSettings();

        fullscreenT.onValueChanged.AddListener(delegate { OnFullScreenToggle(); });
        resolutionD.onValueChanged.AddListener(delegate { ResolutionChange(); });
        qualityD.onValueChanged.AddListener(delegate { QualityChange(); });
        vSyncD.onValueChanged.AddListener(delegate { VSyncChange(); });
        applyButton.onClick.AddListener(delegate { OnApplyButtonClick(); });

        resolutions = Screen.resolutions;
        foreach(Resolution resolution in resolutions)
        {
            resolutionD.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }
        LoadSettings();
    }
}
