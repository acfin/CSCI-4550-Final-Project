using UnityEngine;

public class PassivePlayerMaxHealth : Passive
{
    public int baseExtraMaxHealth = 20;

    public override void ApplyEffect(PlayerStats playerStats)
    {
        int extraMaxHealth = baseExtraMaxHealth * level;
        playerStats.maxHealth += extraMaxHealth;
    }
    public override void ApplyEffect(Weapon weapon)
    {
        // Unused by this passive.
    }
}