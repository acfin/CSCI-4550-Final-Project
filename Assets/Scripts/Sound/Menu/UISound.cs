using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISound : MonoBehaviour
{
    AudioSource menuUI;
    [SerializeField] AudioClip levelOne;
    [SerializeField] AudioClip levelTwo;
    [SerializeField] AudioClip levelThree;   

    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
        menuUI = gameObject.GetComponent<AudioSource>();
        gameObject.transform.position = Camera.main.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
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
