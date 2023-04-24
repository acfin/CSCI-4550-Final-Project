using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected GameObject projectilePrefab;
    public string weaponName;
    public Sprite icon;
    public int level = 1;
    public int maxLevel = 7;
    // Base Values
    public int baseDamage;
    public float baseFireRate;
    public float baseProjectileSpeed;
    public float baseDespawnTime;
    
    // Updated Variables depending on weapon level.
    public int damage => baseDamage * level;
    public float fireRate => baseFireRate;
    public float projectileSpeed => baseProjectileSpeed + level * 1.1f;
    public float despawnTime => baseDespawnTime;
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
    
    public void Upgrade()
    {
        if(level < maxLevel)
        {
            level++;
        }
    }
}