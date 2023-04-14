using System.Collections;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject projectilePrefab;
    [SerializeField] public int damage;
    [SerializeField] public float fireRate;
    [SerializeField] protected float projectileSpeed;
    [SerializeField] protected float despawnTime = 5f;

    protected abstract void Fire();
    protected void DespawnProjectile(GameObject projectile)
    {
        Destroy(projectile);
    }
    
    protected IEnumerator DespawnProjectileAfterTime(GameObject projectile, float time)
    {
        yield return new WaitForSeconds(time);
        DespawnProjectile(projectile);
    }
}