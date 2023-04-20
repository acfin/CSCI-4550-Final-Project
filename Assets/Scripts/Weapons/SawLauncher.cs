using UnityEngine;

public class SawLauncher : Weapon
{
    private float nextFireTime;
    public int numberOfProjectiles = 5;
    public float coneAngle = 30f;

    void Update()
    {
        if (Time.time > nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
        }
    }
    
    protected override void Fire()
    {
        for (int i = 0; i < numberOfProjectiles; i++)
        {
            Vector3 fireDirection = Quaternion.Euler(0, Random.Range(-coneAngle / 2, coneAngle / 2), 0) * transform.forward;

            GameObject sawProjectile = Instantiate(projectilePrefab, transform.position + Vector3.up * .5f, Quaternion.LookRotation(fireDirection));
            sawProjectile.GetComponent<Rigidbody>().velocity = fireDirection * projectileSpeed;
            sawProjectile.GetComponent<SawProjectile>().InitializeProjectile(damage, despawnTime);
        }
    }
}