using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGrenadeSoundManager : MonoBehaviour
{
    AudioSource grenadeAudio;

    [SerializeField] AudioClip grenadePull;
    [SerializeField] AudioClip grenadeExplosion;
    private void Awake()
    {
        grenadeAudio = GetComponent<AudioSource>();
    }

    public void explodeGrenade()
    {
        grenadeAudio.Stop();
        grenadeAudio.PlayOneShot(grenadeExplosion);
        Invoke("PullEnemySound", 0.05f);
    }

    void PullEnemySound()
    {
        grenadeAudio.clip = grenadePull;
        grenadeAudio.Play();
    }
}
