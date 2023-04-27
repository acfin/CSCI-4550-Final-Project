using System.Collections;
using UnityEngine;

public class Scout : Enemy
{
    public GameObject projectilePrefab;
    public int projectilesToShoot = 5;
    public float timeBetweenShots = 0.5f;
    public float bulletSpeed = 10f;
    public float offsetAngle = 10f;
    
    private bool playerInRange = false;
    

    public override void Update()
    {
        base.Update();

        if (playerInRange)
        {
            StartCoroutine(ShootProjectiles());
        }
    }

    private IEnumerator ShootProjectiles()
    {
        playerInRange = false;

        float angleBetweenProjectiles = 360f / projectilesToShoot;
        for (int i = 0; i < projectilesToShoot; i++)
        {
            float angle = i * angleBetweenProjectiles + offsetAngle;
            Vector3 spawnPosition = new Vector3(transform.position.x, 0.75f, transform.position.z);
            GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
            Vector3 direction = Quaternion.Euler(0, angle, 0) * Vector3.forward;
            projectile.GetComponent<Rigidbody>().velocity = direction * bulletSpeed;
        }

        yield return new WaitForSeconds(timeBetweenShots);

        playerInRange = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}