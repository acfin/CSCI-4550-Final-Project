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

    public void StartGame()
    {
        SceneManager.LoadScene(gameScene);
    }
    
    public void PlasmaPistol()
    {
        StartingWeapon.Instance.selectedWeapon = plasmaPistolPrefab;
        StartGame();
    }

    public void SawLauncher()
    {
        StartingWeapon.Instance.selectedWeapon = sawLauncherPrefab;
        StartGame();
    }

    public void GravityGrenadeLauncher()
    {
        StartingWeapon.Instance.selectedWeapon = gravityGrenadeLauncherPrefab;
        StartGame();
    }

    public void RandomWeapon()
    {
        Weapon[] weapons = new Weapon[] { plasmaPistolPrefab, sawLauncherPrefab, gravityGrenadeLauncherPrefab };
        StartingWeapon.Instance.selectedWeapon = weapons[Random.Range(0, weapons.Length)];
        StartGame();
    }
}