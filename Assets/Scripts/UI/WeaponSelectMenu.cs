using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WeaponSelectMenu : MonoBehaviour
{
    public int gameScene = 3;
    public Weapon plasmaPistolPrefab;
    public Weapon sawLauncherPrefab;
    public Weapon gravityGrenadeLauncherPrefab;
    public StartingWeapon selectedWeapon;
    
    public void StartGame()
    {
        SceneManager.LoadScene(gameScene);
    }
    
    public void PlasmaPistol()
    {
        selectedWeapon.selectedWeapon = plasmaPistolPrefab;
        StartGame();
    }

    public void SawLauncher()
    {
        selectedWeapon.selectedWeapon = sawLauncherPrefab;
        StartGame();
    }
    
    public void GravityGrenadeLauncher()
    {
        selectedWeapon.selectedWeapon = gravityGrenadeLauncherPrefab;
        StartGame();
    }

    public void RandomWeapon()
    {
        Weapon[] weapons = new Weapon[] { plasmaPistolPrefab, sawLauncherPrefab, gravityGrenadeLauncherPrefab };
        selectedWeapon.selectedWeapon = weapons[Random.Range(0, weapons.Length)];
        StartGame();
    }
}