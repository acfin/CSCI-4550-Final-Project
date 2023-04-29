using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public Button restart, mainMenu, quit;
    public string thisScene, mainMenuScene;
    public TextMeshProUGUI time, slain, score, highScoreText;
    public Timer timer;
    private int highScore;

    public void updateStats()
    {
        PlayerStats pStats = GameObject.FindGameObjectWithTag("PlayerStats").GetComponent<PlayerStats>();
        highScore = pStats.enemiesSlain + timer.minuteCount * 10;
        slain.text = "Enemies Slain: " + pStats.enemiesSlain;
        score.text = "Score: " + highScore;
        if (timer.secondsCount < 10)
        {
            time.text = "Time Elapsed: " + timer.minuteCount + ":0" + (int)timer.secondsCount;   
        }
        else
        {
            time.text = "Time Elapsed: " + timer.minuteCount + ":" + (int)timer.secondsCount;
        }
        
        // Check if high score in PlayerPrefs is lower than current score & replace it.
        if (PlayerPrefs.GetInt("HighScore", 0) < highScore)
        {
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
        // Update high score text
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0);
    }
    public void restartScene()
    {
        SceneManager.LoadScene(thisScene);
    }

    public void goToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuScene);
    }

    public void quiteGame()
    {
        Application.Quit();
    }
}
