using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class Enemy : MonoBehaviour
{
    // Base Enemy class, all unique enemies will inherit from this.
    public int HP = 100;
    public int Damage = 1;
    public int ExpGiven = 50;
    public float movementSpeed = 3f;
    [SerializeField] protected  AudioClip takeDamage;
    [SerializeField] protected AudioMixerGroup soundfx;

    private GameObject player;
    private DamageTextManager damageTextManager;
    private NavMeshAgent navMeshAgent;

    // Handles the item drops
    public GameObject powerUp;
    public GameObject healingDrop;
    public GameObject shieldDrop;

    private float speedRNG = 0.02f;
    private float healingRNG = 0.02f;
    private float shieldRNG = 0.02f;

    bool speedSpawned = false;
    bool healingSpawned = false;
    bool shieldSpawned = false;
    static public int speedCount;
    static public int shieldCount;
    static public int healingCount;

    protected virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        damageTextManager = GetComponent<DamageTextManager>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = movementSpeed;
    }

    public virtual void Update()
    {
        MoveTowardsPlayer();
        // Out of bounds check
        if (transform.position.y <= -15f)
        {
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        //SoundFX
        bool value = soundfx.audioMixer.GetFloat("Sound", out float volume);
        volume = Mathf.Pow(10f, volume / 20);
        AudioSource.PlayClipAtPoint(takeDamage, gameObject.transform.position, volume);
        //
        if (damageTextManager)
        {
            damageTextManager.DisplayDamage(damage);
        }
        if (HP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameObject player = GameObject.FindGameObjectWithTag("PlayerStats");
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        if (playerStats != null)
        {
            playerStats.enemiesSlain += 1;
            playerStats.AddExperience(ExpGiven);
        }

        if (!speedSpawned && speedCount < 2 && UnityEngine.Random.value <= speedRNG)
        {
            DropPowerUp();
            speedSpawned = true;
            speedCount++;
        }

        if (!healingSpawned && healingCount < 4 && UnityEngine.Random.value <= 1)
        {
            DropHealing();
            bool healingSpawned = true;
            healingCount++;
        }

        if (!shieldSpawned && shieldCount < 2 && UnityEngine.Random.value <= shieldRNG)
        {
            DropShield();
            shieldSpawned = true;
            shieldCount++;
        }

        Destroy(gameObject);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player = GameObject.FindGameObjectWithTag("PlayerStats");
            PlayerStats playerStats = player.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(Damage);
            }
        }
    }
    
    
    private void MoveTowardsPlayer()
    {
        if (player != null)
        {
            navMeshAgent.SetDestination(player.transform.position);
        }
    }

    // Old movement function, NavMesh seems to accomplish our movement better.
    /*private void MoveTowardsPlayer()
    {
        if (player != null)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;

            // Make the enemy face the player
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            Vector3 movement = direction * movementSpeed * Time.deltaTime;
            transform.position += movement;
        }
    }*/

    void DropPowerUp()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0f, 1f, 0f);
        Instantiate(powerUp, spawnPosition, Quaternion.identity);
    }
    void DropHealing()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0f, 1f, 0f);
        Instantiate(healingDrop, spawnPosition, Quaternion.identity);
    }
    void DropShield()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0f, 1f, 0f);
        Instantiate(shieldDrop, spawnPosition, Quaternion.identity);
    }
}