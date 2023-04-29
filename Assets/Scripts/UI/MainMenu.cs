using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int weaponSelectScene = 1;
    public int settingsScene = 2;
    public TextMeshProUGUI highScore;
    // Start is called before the first frame update
    void Start()
    {
        highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(weaponSelectScene);
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
