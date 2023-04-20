using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMenu : MonoBehaviour
{
    public PlasmaPistol plasmaPistol;
    public Inventory inventory;
    public EnemySpawner enemySpawner;
    public GameObject wave1Prefab;
    public GameObject wave2Prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPlasmaPistol()
    {
        inventory.AddWeapon(plasmaPistol);
    }

    public void SpawnWave1()
    {
        enemySpawner.SpawnEnemy(wave1Prefab, 5);
    }
    public void SpawnWave2()
    {
        enemySpawner.SpawnEnemy(wave2Prefab, 10);
    }
}
