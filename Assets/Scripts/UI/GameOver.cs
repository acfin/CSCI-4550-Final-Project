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
    public TextMeshProUGUI time, slain;
    public Timer timer;

    public void updateStats()
    {
        PlayerStats pStats = GameObject.FindGameObjectWithTag("PlayerStats").GetComponent<PlayerStats>();
        slain.text = "EnemiesSlain: " + pStats.enemiesSlain;
        time.text = "Enemies Slain: " + timer.minuteCount + ":" + (int)timer.secondsCount;
    }
    public void restartScene()
    {
        SceneManager.LoadScene(thisScene);
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    public void quiteGame()
    {
        Application.Quit();
    }
}
