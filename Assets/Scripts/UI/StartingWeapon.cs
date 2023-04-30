using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingWeapon : MonoBehaviour
{
    public static StartingWeapon Instance { get; private set; }

    public Weapon selectedWeapon;
    private string weaponSelectScene = "WeaponSelect";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == weaponSelectScene)
        {
            selectedWeapon = null;
        }
    }
}