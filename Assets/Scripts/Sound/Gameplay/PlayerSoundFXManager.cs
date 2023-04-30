using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundFXManager : MonoBehaviour
{
    [SerializeField] AudioClip plasmaPistol;
    [SerializeField] AudioClip saw;
    [SerializeField] AudioClip weaponPickup;
    [SerializeField] AudioClip takeDamage;

    AudioSource playerAudio;

    bool isTakingDamage = false;

    // Start is called before the first frame update
    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDamage()
    {
        playerAudio.PlayOneShot(takeDamage);
    }

    public void PickupWeapon()
    {
        playerAudio.PlayOneShot(weaponPickup);
    }

    public void LaunchSaw()
    {
        playerAudio.PlayOneShot(saw);
    }

    public void FirePistol()
    {
        playerAudio.PlayOneShot(plasmaPistol);
    }
}
