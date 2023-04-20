using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public GameObject[] waveEnemy;
    public int[] numOfEnemies;
    public int waveLength = 60;
    public int waveNum = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartWave());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartWave()
    {
        if(waveNum <= waveEnemy.Length);
        {
            enemySpawner.SpawnEnemy(waveEnemy[waveNum], numOfEnemies[waveNum]);
            yield return new WaitForSeconds(waveLength);
        }
    }
}
