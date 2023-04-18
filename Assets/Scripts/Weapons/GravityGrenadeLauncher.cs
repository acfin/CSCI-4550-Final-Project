using UnityEngine;

public class GravityGrenadeLauncher : Weapon
{
    private float nextFireTime;
    public int numberOfProjectiles = 1;
    public float explodeTime = 2f;
    public float explosionRadius = 10f;

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
        Vector3 fireDirection = transform.forward;
        GameObject grenadeProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.LookRotation(fireDirection));
        grenadeProjectile.GetComponent<Rigidbody>().velocity = fireDirection * projectileSpeed;
        grenadeProjectile.GetComponent<GravityGrenadeProjectile>().InitializeProjectile(damage, despawnTime, explodeTime, explosionRadius);
    }
}