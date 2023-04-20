using UnityEngine;

public class PassivePlayerHealthRegeneration : Passive
{
    public int baseExtraHealthRegenPerSecond = 1;

    public override void ApplyEffect(PlayerStats playerStats)
    {
        int extraHealthRegenPerSecond = baseExtraHealthRegenPerSecond * level;
        playerStats.healthRegenRate += extraHealthRegenPerSecond;
    }
    public override void ApplyEffect(Weapon weapon)
    {
        // Unused by this passive.
    }
}