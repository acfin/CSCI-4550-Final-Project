using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public int damage = 3;
    public float lifetime = 5f;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            Debug.Log("Bullet hit");
            GameObject player = GameObject.FindGameObjectWithTag("PlayerStats");
            PlayerStats playerStats = player.GetComponent<PlayerStats>();
            if (playerStats != null)
            {
                playerStats.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}