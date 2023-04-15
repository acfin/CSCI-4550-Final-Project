using UnityEngine;

public class PassiveWeaponFireRate : Passive
{
    public float fireRateMultiplierPerLevel = 0.2f;

    public override void ApplyEffect(PlayerStats playerStats)
    {
        // Unused by this passive.
    }

    public override void ApplyEffect(Weapon weapon)
    {
        weapon.baseFireRate -= level * fireRateMultiplierPerLevel;
    }
}