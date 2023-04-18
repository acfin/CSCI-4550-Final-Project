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

    public int GetExperienceToLevelUp(int currentLevel) => 100 + (int)((currentLevel - 1) * 150);

    public void Start()
    {
        health = maxHealth;
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            AddExperience(25);
        }
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
        if (!isInvincible)
        {
            health -= damage;

            if (health <= 0)
            {
                // Handle game over here.
                Destroy(player);
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
}