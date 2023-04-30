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

    
}