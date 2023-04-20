using UnityEngine;

public class StartingWeapon : MonoBehaviour
{
    public Weapon selectedWeapon;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}