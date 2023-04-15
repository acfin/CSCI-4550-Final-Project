using UnityEngine;

public class PassivePlayerSpeed : Passive
{
    public float baseSpeedMultiplier = .75f;

    public override void ApplyEffect(PlayerStats playerStats)
    {
        float speedMultiplier = baseSpeedMultiplier * level;
        
        playerStats.speed += speedMultiplier;
    }
    public override void ApplyEffect(Weapon weapon)
    {
        // Unused by this passive.
    }
}