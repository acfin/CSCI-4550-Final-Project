using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int mainScene = 1;
    public int settingsScene = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(mainScene);
    }
    
    public void LoadSettings()
    {
        SceneManager.LoadScene(settingsScene);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
