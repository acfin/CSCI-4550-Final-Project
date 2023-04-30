using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISound : MonoBehaviour
{
    public static UISound Instance { get; private set; }

    AudioSource menuUI;
    [SerializeField] AudioClip levelOne;
    [SerializeField] AudioClip levelTwo;
    [SerializeField] AudioClip levelThree;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            menuUI = gameObject.GetComponent<AudioSource>();
            gameObject.transform.position = Camera.main.transform.position;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void playLevelOne()
    {
        menuUI.PlayOneShot(levelOne);
    }

    public void playLevelTwo()
    {
        menuUI.PlayOneShot(levelTwo);
    }

    public void playLevelThree()
    {
        menuUI.PlayOneShot(levelThree);
    }
}