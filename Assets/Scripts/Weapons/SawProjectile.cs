using UnityEngine;

public class SawProjectile : MonoBehaviour
{
    private int damage;
    private float despawnTime;
    private float spawnTime;

    public void InitializeProjectile(int damage, float despawnTime)
    {
        this.damage = damage;
        this.despawnTime = despawnTime;
        this.spawnTime = Time.time;
    }

    private void Update()
    {
        if (Time.time > spawnTime + despawnTime)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}