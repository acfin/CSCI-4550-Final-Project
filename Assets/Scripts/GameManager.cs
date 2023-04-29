using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[Serializable]
public class WaveData
{
    public GameObject enemyPrefab;
    public int numberOfEnemies;
}
public class GameManager : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public List<WaveData> waveData;
    public List<GameObject> bosses;
    public int waveLength = 60;
    public int waveNum = 0;
    private bool victory = false;

    public TextMeshProUGUI waveText;
    public WaveHUD waveHUD;
    public GameObject victoryScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        StartCoroutine(StartWave());
    }

    void SpawnBoss()
    {
        // Wave 5 Boss
        if (waveNum == 4)
        {
            enemySpawner.SpawnBoss(bosses[0]);
        }
        // Wave 10 Boss
        else if (waveNum == 9)
        {
            enemySpawner.SpawnBoss(bosses[1]);
        }
        // Wave 15 Boss
        else if (waveNum == 14)
        {
            enemySpawner.SpawnBoss(bosses[2]);
        }
        // Wave 20 Boss
        else if (waveNum == 19)
        {
            enemySpawner.SpawnBoss(bosses[3]);
        }
        // Wave 25 Boss
        else if (waveNum == 24)
        {
            enemySpawner.SpawnBoss(bosses[4]);
        }
    }

    IEnumerator StartWave()
    {
        while (!victory)
            if (waveNum < waveData.Count)
            {
                SpawnBoss();
                Debug.Log("waveEnemy.Length");
                Debug.Log("Spawning Wave: " + waveNum);
                enemySpawner.SpawnEnemy(waveData[waveNum].enemyPrefab, waveData[waveNum].numberOfEnemies);
                waveText.text = (waveNum+1).ToString();
                waveHUD.secondsCount = waveLength;
                waveHUD.waveLength = waveLength;
                yield return new WaitForSeconds(waveLength);
                waveNum++;


            }
            // Last wave
            else if (waveNum == waveData.Count)
            {
                yield return new WaitForSeconds(waveLength);
                victory = true;
                Time.timeScale = 0f;
                victoryScreen.GetComponent<Canvas>().enabled = true;
                victoryScreen.GetComponent<VictoryScreen>().updateStats();
            }
    }
}
