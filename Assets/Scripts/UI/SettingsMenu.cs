using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown; // Reference to your Dropdown component
    public int sceneNum = 0;

    private void Start()
    {
        // Add a listener to the dropdown
        resolutionDropdown.onValueChanged.AddListener(delegate {
            SetResolution(resolutionDropdown.value);
        });
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(sceneNum);
    }

    public void SetResolution(int index)
    {
        switch (index)
        {
            case 0:
                Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);
                break;
            case 1:
                Screen.SetResolution(1600, 900, FullScreenMode.FullScreenWindow);
                break;
            case 2:
                Screen.SetResolution(1366, 768, FullScreenMode.FullScreenWindow);
                break;
            case 3:
                Screen.SetResolution(1280, 720, FullScreenMode.FullScreenWindow);
                break;
            case 4:
                Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
                break;
            case 5:
                Screen.SetResolution(1600, 900, FullScreenMode.Windowed);
                break;
            case 6:
                Screen.SetResolution(1366, 768, FullScreenMode.Windowed);
                break;
            case 7:
                Screen.SetResolution(1280, 720, FullScreenMode.Windowed);
                break;
            default:
                Debug.LogError("Invalid resolution index");
                break;
        }
    }
}