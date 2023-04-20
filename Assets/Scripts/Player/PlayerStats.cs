using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{
    public int level = 1;
    public int experience = 0;

    public float speed = 10f;
    public int maxHealth = 100;
    public int health;
    public bool isInvincible = false;
    public float invincibleDur = 1f;
    public float healthRegenRate = 1f;

    public GameObject player;

    public UnityEvent OnLevelUp;
    private Animator animator;
    private DamageTextManager damageTextManager;

    public int GetExperienceToLevelUp(int currentLevel) => 100 + (int)((currentLevel - 1) * 150);

    public void Start()
    {
        health = maxHealth;
        damageTextManager = player.GetComponent<DamageTextManager>();
        animator = player.GetComponent<Animator>();
    }

    public void AddExperience(int exp)
    {
        experience += exp;
        if (experience >= GetExperienceToLevelUp(level))
        {
            experience -= GetExperienceToLevelUp(level);
            level++;
            if (OnLevelUp != null)
            {
                OnLevelUp.Invoke();
            }
        }
    }

    public void TakeDamage(int damage)
    {
        animator.SetTrigger("Damage");
        if (!isInvincible)
        {
            health -= damage;

            if (damageTextManager)
            {
                damageTextManager.DisplayDamage(damage);
            }
            if (health <= 0)
            {
                // Handle game over here.
                StartCoroutine(GameOver());
            }

            StartCoroutine(InvincibilityRoutine());
        }
    }
    private IEnumerator InvincibilityRoutine()
    {
        isInvincible = true;
        yield return new WaitForSeconds(invincibleDur);
        isInvincible = false;
    }

    private IEnumerator GameOver()
    {
        Destroy(player.GetComponent<MovementController>());
        Destroy(player.GetComponent<DamageTextManager>());
        Destroy(player.GetComponentInChildren<Weapon>());
        animator.SetTrigger("Death");
        yield return new WaitForSeconds(2);
        // Load game over scene/UI element
    }
}