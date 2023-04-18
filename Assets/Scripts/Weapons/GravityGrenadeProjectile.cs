using UnityEngine;

public class GravityGrenadeProjectile : MonoBehaviour
{
    private int damage;
    private float despawnTime;
    private float spawnTime;
    private float explodeTime;
    
    private float explosionRadius = 10f;
    public float pullForce = 25f;
    private bool exploded = false;

    public void InitializeProjectile(int damage, float despawnTime, float explodeTime, float explosionRadius)
    {
        this.exploded = false;
        this.damage = damage;
        this.despawnTime = despawnTime;
        this.spawnTime = Time.time;
        this.explodeTime = explodeTime;
        this.explosionRadius = explosionRadius;
    }

    private void Update()
    {
        if (Time.time > spawnTime + despawnTime)
        {
            Destroy(gameObject);
        }
        else if (Time.time > spawnTime + explodeTime && !exploded)
        {
            exploded = true;
            Explode();
        }
        else if (!exploded)
        {
            PullEnemies();
        }
    }

    private void Explode()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponentInChildren<Light>().enabled = false;
        // TODO: Add explosion particle effect, sound effect
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Enemy enemy = collider.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                }
            }
        }

    }
    
    private void PullEnemies()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Rigidbody rb = collider.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    Vector3 direction = (transform.position - collider.transform.position).normalized;
                    rb.AddForce(direction * pullForce * Time.deltaTime, ForceMode.Force);
                }
            }
        }
    }
    
    
}