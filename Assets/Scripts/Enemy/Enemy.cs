using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Base Enemy class, all unique enemies will inherit from this.
    public int HP = 100;
    public int Damage = 1;
    public int ExpGiven = 50;

    public void TakeDamage(int damage)
    {
        HP -= damage;

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
            Debug.Log("Hello?");
            GameObject player = GameObject.FindGameObjectWithTag("PlayerStats");
            PlayerStats playerStats = player.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(Damage);
            }
        }
    }
}