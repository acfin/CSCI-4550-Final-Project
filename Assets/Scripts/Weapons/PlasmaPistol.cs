using UnityEngine;
using System.Collections.Generic;

public class PlasmaPistol : Weapon
{
    private float nextFireTime;
    private List<Quaternion> fireDirections;

    void Start()
    {
        nextFireTime = Time.time;
        SetFireDirections();
    }

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
        foreach (Quaternion fireDirection in fireDirections)
        {
            GameObject projectileInstance = Instantiate(projectilePrefab, transform.position, fireDirection);
            Rigidbody projectileRigidbody = projectileInstance.GetComponent<Rigidbody>();
            projectileRigidbody.velocity = fireDirection * Vector3.forward * projectileSpeed;

            PlasmaProjectile plasmaProjectile = projectileInstance.GetComponent<PlasmaProjectile>();
            if (plasmaProjectile != null)
            {
                plasmaProjectile.InitializeProjectile(damage, despawnTime);
            }
        }
    }
    private void SetFireDirections()
    {
        fireDirections = new List<Quaternion>
        {
            transform.rotation * Quaternion.Euler(0, 45, 0),
            transform.rotation * Quaternion.Euler(0, 135, 0),
            transform.rotation * Quaternion.Euler(0, 225, 0),
            transform.rotation * Quaternion.Euler(0, 315, 0)
        };
    }
}