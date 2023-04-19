using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Base Enemy class, all unique enemies will inherit from this.
    public int HP = 100;
    public int Damage = 1;
    public int ExpGiven = 50;
    public float movementSpeed = 3f;
    private GameObject player;
    private DamageTextManager damageTextManager;
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        damageTextManager = GetComponent<DamageTextManager>();
    }

    public void Update()
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
            Vector3 direction = (player.transform.position - transform.position).normalized;
            Vector3 movement = direction * movementSpeed * Time.deltaTime;
            transform.position += movement;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            // Move up or down along the y-axis
            float verticalDirection = UnityEngine.Random.Range(-1f, 1f);
            transform.position += new Vector3(0, verticalDirection * movementSpeed * Time.deltaTime, 0);
        }
    }
}