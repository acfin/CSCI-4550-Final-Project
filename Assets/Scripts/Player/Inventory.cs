using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int weaponCapacity = 3;
    public int passiveCapacity = 3;
    
    public GameObject player;
    public List<Weapon> weapons;
    private List<Passive> passives;
    public PlayerStats playerStats;
    public InventoryUIManager hud;

    public Weapon defaultWeapon;

    void Start()
    {
        weapons = new List<Weapon>();
        passives = new List<Passive>();
        StartingWeapon selectedWeapon = FindObjectOfType<StartingWeapon>();
        if (selectedWeapon != null)
        {
            AddWeapon(selectedWeapon.selectedWeapon);
        }
        else if(selectedWeapon == null)
        {
            AddWeapon(defaultWeapon);
        }
    }
    
    // Add Weapon to inventory. 
    public bool AddWeapon(Weapon weapon)
    {
        Weapon existingWeapon = weapons.Find(w => w.weaponName == weapon.weaponName);
        if (existingWeapon != null)
        {
            existingWeapon.Upgrade();
            hud.updateWeapons(weapons);
            return true;
        }
        if (weapons.Count < weaponCapacity)
        {
            Weapon newWeapon = Instantiate(weapon, player.transform.position, player.transform.rotation, player.transform);
            weapons.Add(newWeapon);
            hud.updateWeapons(weapons);
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
            existingPassive.Upgrade();
            PassiveUpgrade(existingPassive);
            hud.updatePassives(passives);
            return true;
        }
        if (passives.Count < passiveCapacity)
        {
            Passive newPassive = Instantiate(passive, player.transform.position, player.transform.rotation, player.transform);
            passives.Add(newPassive);
            PassiveUpgrade(newPassive);
            hud.updatePassives(passives);
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
    
    public bool IsWeaponAtMaxLevel(Weapon weaponTemplate)
    {
        Weapon weaponInInventory = weapons.Find(w => w.weaponName == weaponTemplate.weaponName);
        return weaponInInventory != null && weaponInInventory.level >= weaponInInventory.maxLevel;
    }

    public bool IsPassiveAtMaxLevel(Passive passiveTemplate)
    {
        Passive passiveInInventory = passives.Find(p => p.passiveName == passiveTemplate.passiveName);
        return passiveInInventory != null && passiveInInventory.level >= passiveInInventory.maxLevel;
    }
    
    public bool AreAllItemsAtMaxLevel()
    {
        return weapons.TrueForAll(weapon => weapon.level >= weapon.maxLevel) &&
               passives.TrueForAll(passive => passive.level >= passive.maxLevel);
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