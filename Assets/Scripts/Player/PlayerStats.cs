using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public int level = 1;
    public int experience = 0;
    public int experienceToLevelMod = 200;
    public float speed = 10f;
    public int maxHealth = 100;
    public int health;
    public bool isInvincible = false;
    public float invincibleDur = 1f;
    public int healthRegenRate = 1;

    public Slider healthbar, xpbar;

    public GameObject player;

    public UnityEvent OnLevelUp;
    private Animator animator;
    private DamageTextManager damageTextManager;
    public GameObject gameOverScreen;
    public int enemiesSlain;

    PlayerSoundFXManager soundfx;

    public int GetExperienceToLevelUp(int currentLevel) => (int)(Math.Pow(currentLevel, 1.5) * experienceToLevelMod);

    public void Start()
    {
        enemiesSlain = 0;
        health = maxHealth;
        updateHealthbar();
        damageTextManager = player.GetComponent<DamageTextManager>();
        animator = player.GetComponent<Animator>();
        StartCoroutine(RegenRoutine());
        soundfx = GameObject.Find("Player").GetComponent<PlayerSoundFXManager>();
    }

    public void AddExperience(int exp)
    {
        experience += exp;
        updateXPBar();
        if (experience >= GetExperienceToLevelUp(level))
        {
            experience -= GetExperienceToLevelUp(level);
            level++;
            updateXPBar();
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
            soundfx.TakeDamage();
            health -= damage;
            updateHealthbar();

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
    
    private IEnumerator RegenRoutine()
    {
        while (true)
        {
            if (health < maxHealth)
            {
                health += healthRegenRate;
                updateHealthbar();
            }
            yield return new WaitForSeconds(5f);
        }
    }

    private IEnumerator GameOver()
    {
        Destroy(player.GetComponent<MovementController>());
        Destroy(player.GetComponent<DamageTextManager>());
        // Destroy all Weapon components in the player and its children
        Weapon[] weapons = player.GetComponentsInChildren<Weapon>();
        foreach (Weapon weapon in weapons)
        {
            Destroy(weapon);
        }
        animator.SetTrigger("Death");
        // See death animation before gameover screen
        yield return new WaitForSeconds(4);

        // TODO: Load game over scene/UI element
        gameOverScreen.GetComponent<Canvas>().enabled = true;
        gameOverScreen.GetComponent<GameOver>().updateStats();
        Time.timeScale = 0f;
    }

    private void updateHealthbar()
    {
        healthbar.maxValue = maxHealth;
        healthbar.value = health;
    }

    private void updateXPBar()
    {
        xpbar.maxValue = GetExperienceToLevelUp(level);
        xpbar.value = experience;
    }
}