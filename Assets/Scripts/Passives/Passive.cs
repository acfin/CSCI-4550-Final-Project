using UnityEngine;

public abstract class Passive : MonoBehaviour
{
    public int level = 1;
    public int maxLevel = 5;
    public string passiveName;
    public abstract void ApplyEffect(PlayerStats playerStats);
    public abstract void ApplyEffect(Weapon weapon);
    
    public void Upgrade()
    {
        if(level < 5)
        {
            level++;
            Debug.Log("passive levelup");
        }
    }
}