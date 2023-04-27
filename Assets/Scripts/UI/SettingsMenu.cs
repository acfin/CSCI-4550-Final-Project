using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameObject toggle;
    public int sceneNum = 0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene(sceneNum);
    }

    public void setScreenMode()
    {
        if (Screen.fullScreenMode != FullScreenMode.Windowed)
        {
            toggle.GetComponent<Toggle>().isOn = true;
            //Screen.fullScreenMode = FullScreenMode.Windowed;
            Screen.SetResolution(1280, 720, FullScreenMode.Windowed);
            
        }

        else
        {
            toggle.GetComponent<Toggle>().isOn = false;
            Screen.SetResolution(1920, 1080, FullScreenMode.FullScreenWindow);
            //Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }
    }
}
