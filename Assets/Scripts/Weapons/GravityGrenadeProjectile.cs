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
    private bool explodedEffect = false;

    public GameObject particlePrefab;
    public ParticleSystem particle;

    private void Start()
    {
        // Instantiate the particle system prefab as a child of the projectile
        GameObject particleObject = Instantiate(particlePrefab, transform.position, Quaternion.identity, transform);
        particle = particleObject.GetComponent<ParticleSystem>();
        particle.Stop();
    }
    public void InitializeProjectile(int damage, float despawnTime, float explodeTime, float explosionRadius)
    {
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
        // Add a small delay between the explosion effect and damaging the enemies.
        else if (Time.time > spawnTime + explodeTime - .15f && !explodedEffect)
        {
            explodedEffect = true;
            ExplodeEffect();
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

    private void ExplodeEffect()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponentInChildren<Light>().enabled = false;
        // TODO: Add sound effect
        particle.Play();
    }

    private void Explode()
    {
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