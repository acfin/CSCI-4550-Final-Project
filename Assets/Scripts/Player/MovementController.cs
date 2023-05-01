using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovementController : MonoBehaviour
{
    public PlayerStats playerStats;
    public float speed = 5f;
    private Rigidbody rb;
    private Vector3 moveDirection;
    private Animator animator;

    private bool hasPowerUp = false;
    private float powerUpDuration = 2f;
    private float powerUpStrength = 3;

    private int healAmount = 10;
    private DamageTextManager healText;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        speed = playerStats.speed;
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        moveDirection.Normalize();
        
        if (moveDirection.Equals(new Vector3(0, 0 , 0)))
        {
            animator.SetFloat("Speed", 0f);
        }
        else
        {
            animator.SetFloat("Speed", .75f);
        }
        
        
        // Update rotation based on movement direction
        if (moveDirection != Vector3.zero)
        {
            float angle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, angle, 0);
        }
        
        // Out of Bounds check
        if (transform.position.y < -10f)
        {
            transform.position = new Vector3(3, 1, -3);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + moveDirection * speed * Time.deltaTime);
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Forcefield"))
        {

            Destroy(other.gameObject);
            if (other.CompareTag("PowerUp"))
            {
                Destroy(other.gameObject);
                if (!hasPowerUp)
                {
                    hasPowerUp = true;
                    playerStats.speed += powerUpStrength;
                    StartCoroutine(SpeedCooldown());
                }
                Enemy.speedCount--;
            }

            if (other.CompareTag("Heal"))
            {
                Destroy(other.gameObject);
                playerStats.health += healAmount;
                if (playerStats.health > playerStats.maxHealth)
                {
                    playerStats.health = playerStats.maxHealth;
                }
                playerStats.updateHealthbar();
                Enemy.healingCount--;
            }

            if (other.CompareTag("Shield"))
            {
                Destroy(other.gameObject);
                if (playerStats.hasShield == false)
                {
                    playerStats.hasShield = true;
                    playerStats.shieldHealth = 5;
                }
                Enemy.shieldCount--;
            }
        }
    }


    IEnumerator SpeedCooldown()
    {
        yield return new WaitForSeconds(powerUpDuration);
        playerStats.speed -= powerUpStrength;
        hasPowerUp = false;
    }
}