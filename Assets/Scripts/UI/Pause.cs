using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Pause : MonoBehaviour
{
    public string mainMenuScene;
    public TextMeshProUGUI time, slain;
    public Timer timer;
    public GameObject pauseMenu; 
    public LevelUp levelUp;

    private bool isPaused = false;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        // If level up panel is active, don't toggle pause menu (prevents timeScale issues)
        if (levelUp.levelUpPanel.activeSelf) 
        {
            return; 
        }
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);
        Time.timeScale = isPaused ? 0 : 1;
        if (isPaused)
        {
            updateStats();
        }
    }

    public void updateStats()
    {
        PlayerStats pStats = GameObject.FindGameObjectWithTag("PlayerStats").GetComponent<PlayerStats>();
        slain.text = "Enemies Slain: " + pStats.enemiesSlain;
        time.text = "Time: " + timer.minuteCount + ":" + (int)timer.secondsCount;
    }

    public void goToMainMenu()
    {
        Time.timeScale = 1; // Unpause the game before loading the main menu
        SceneManager.LoadScene(mainMenuScene);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}