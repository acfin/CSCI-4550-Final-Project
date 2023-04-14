using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int weaponCapacity = 3;
    public int passiveCapacity = 3;

    public Weapon startingWeapon;

    public bool test = false;
    
    private List<Weapon> weapons;
    private List<Passive> passives;
    public GameObject player;

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

    // Add Passive to inventory. Set to cap of 3
    // TODO: When level-up system is implemented do not show new passives on level-up if cap is reached.
    public bool AddPassive(Passive passive)
    {
        if (passives.Count < passiveCapacity)
        {
            passives.Add(passive);
            return true;
        }
        else
        {
            return false;
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