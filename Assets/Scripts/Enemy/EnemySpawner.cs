using System.Collections;
using Mono.Cecil;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private GameObject enemyPrefab;
    private int maxNumberOfEnemies;
    private GameObject player;
    
    public float minSpawnDistance = 10f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(SpawnEnemies());
    }
    
    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            int currentNumberOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
            if (currentNumberOfEnemies < maxNumberOfEnemies && enemyPrefab != null)
            {
                Vector3 spawnPosition = GetRandomSpawnPosition();
                Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            }
            yield return new WaitForSeconds(1f);
        }
    }

    public void SpawnEnemy(GameObject enemyPrefab, int enemies = 10)
    {
        this.maxNumberOfEnemies = enemies;
        this.enemyPrefab = enemyPrefab;
    }
    

    private Vector3 GetRandomSpawnPosition()
    {
        BoxCollider[] spawnZones = GetComponentsInChildren<BoxCollider>();
        BoxCollider playerZone = null;
        foreach (BoxCollider zone in spawnZones)
        {
            if (!player)
            {
                break;
            }
            if (zone.bounds.Contains(player.transform.position))
            {
                playerZone = zone;
                break;
            }
        }
        BoxCollider selectedZone;
        // Prevents an enemy from spawning in the same BoxCollider as the player
        do
        {
            selectedZone = spawnZones[Random.Range(0, spawnZones.Length)];
        }
        while (selectedZone == playerZone);

        Vector3 spawnPosition;
        int attempts = 0;
        const int maxAttempts = 25;

        // If the randomly generated location is too close to the player, it will recalculate a spawn area.
        // If max attempts is reached, it will use the last attempted location. (Prevents infinite while loop)
        do
        {
            spawnPosition = new Vector3(
                Random.Range(selectedZone.bounds.min.x, selectedZone.bounds.max.x),
                (selectedZone.bounds.center.y + selectedZone.bounds.extents.y),
                Random.Range(selectedZone.bounds.min.z, selectedZone.bounds.max.z));
            attempts++;
        }
        while (player && 
               (Vector3.Distance(player.transform.position, spawnPosition) < minSpawnDistance) && attempts < maxAttempts);

        return spawnPosition;
    }

}
