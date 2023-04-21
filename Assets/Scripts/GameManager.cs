using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartWave());
    }

    IEnumerator StartWave()
    {
        while (!victory)
            if (waveNum < waveData.Count)
            {
                // Wave 5 Boss
                if (waveNum == 1)
                {
                    enemySpawner.SpawnBoss(bosses[0]);
                }
                Debug.Log("waveEnemy.Length");
                Debug.Log("Spawning Wave: " + waveNum);
                enemySpawner.SpawnEnemy(waveData[waveNum].enemyPrefab, waveData[waveNum].numberOfEnemies);
                yield return new WaitForSeconds(waveLength);
                waveNum++; 
            }
            // Last wave
            else if (waveNum == waveData.Count)
            {
                yield return new WaitForSeconds(waveLength);
                victory = true;
                // TODO: Victory screen
            }
    }
}
