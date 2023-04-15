using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int weaponCapacity = 3;
    public int passiveCapacity = 3;

    public Weapon startingWeapon;
    public GameObject player;
    
    private List<Weapon> weapons;
    private List<Passive> passives;
    public PlayerStats playerStats;

    void Start()
    {
        weapons = new List<Weapon>();
        passives = new List<Passive>();
        AddWeapon(startingWeapon);
    }
    
    // Add Weapon to inventory. 
    public bool AddWeapon(Weapon weapon)
    {
        Weapon existingWeapon = weapons.Find(w => w.weaponName == weapon.weaponName);
        if (existingWeapon != null)
        {
            existingWeapon.Upgrade();
            return true;
        }
        if (weapons.Count < weaponCapacity)
        {
            Weapon newWeapon = Instantiate(weapon, player.transform.position, player.transform.rotation, player.transform);
            weapons.Add(newWeapon);
            return true;
        }
        else
        {
            return false;
        }
    }

    // Add Passive to inventory. 
    public bool AddPassive(Passive passive)
    {
        Passive existingPassive = passives.Find(p => p.passiveName == passive.passiveName);
        if (existingPassive != null)
        {
            Debug.Log("Upgrade?");
            existingPassive.Upgrade();
            PassiveUpgrade(existingPassive);
            return true;
        }
        if (passives.Count < passiveCapacity)
        {
            Passive newPassive = Instantiate(passive, player.transform.position, player.transform.rotation, player.transform);
            passives.Add(newPassive);
            PassiveUpgrade(newPassive);
            return true;
        }
        else
        {
            return false;
        }
    }

    
    public bool ContainsWeapon(Weapon weapon)
    {
        return weapons.Exists(w => w.weaponName == weapon.weaponName);
    }

    public bool ContainsPassive(Passive passive)
    {
        return passives.Exists(p => p.passiveName == passive.passiveName);
    }
    
    public void PassiveUpgrade(Passive passive)
    {
        // Apply passive to player stat if applicable.
        passive.ApplyEffect(playerStats);

        // Apply passive effect on each weapon in the player's inventory
        foreach (Weapon weapon in weapons)
        {
            passive.ApplyEffect(weapon);
        }
    }

    public List<Weapon> GetWeapons()
    {
        return weapons;
    }

    public List<Passive> GetPassives()
    {
        return passives;
    }
    
}