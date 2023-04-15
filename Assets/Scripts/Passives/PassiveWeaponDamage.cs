using UnityEngine;

public class PassiveWeaponDamage : Passive
{
    public int damageIncreasePerLevel = 1;

    public override void ApplyEffect(PlayerStats playerStats)
    {
        // Unused by this passive.
    }

    public override void ApplyEffect(Weapon weapon)
    {
        weapon.baseDamage += (level * damageIncreasePerLevel);
    }
}