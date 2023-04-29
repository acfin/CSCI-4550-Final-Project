using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class VictoryScreen : MonoBehaviour
{
    public Button restart, mainMenu, quit;
    public string thisScene, mainMenuScene;
    public TextMeshProUGUI time, slain;
    public Timer timer;

    public void updateStats()
    {
        PlayerStats pStats = GameObject.FindGameObjectWithTag("PlayerStats").GetComponent<PlayerStats>();
        slain.text = "Enemies Slain: " + pStats.enemiesSlain;
        //time.text = "Time Elapsed: " + timer.minuteCount + ":" + (int)timer.secondsCount;
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
