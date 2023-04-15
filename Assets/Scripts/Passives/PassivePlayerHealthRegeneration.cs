using UnityEngine;

public class PassivePlayerHealthRegeneration : Passive
{
    public float baseExtraHealthRegenPerSecond = 1.0f;

    public override void ApplyEffect(PlayerStats playerStats)
    {
        float extraHealthRegenPerSecond = baseExtraHealthRegenPerSecond * level;
        playerStats.healthRegenRate += extraHealthRegenPerSecond;
    }
    public override void ApplyEffect(Weapon weapon)
    {
        // Unused by this passive.
    }
}