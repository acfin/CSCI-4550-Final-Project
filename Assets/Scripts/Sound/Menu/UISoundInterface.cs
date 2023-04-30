using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UISoundInterface : MonoBehaviour
{
    UISound uiSound;

    void Start()
    {
        uiSound = GameObject.Find("UISoundPlayer").GetComponent<UISound>();
    }

    public void playLevelOne()
    {
        if (uiSound)
        {
            uiSound.playLevelOne();
        }
    }

    public void playLevelTwo()
    {
        if (uiSound)
        {
            uiSound.playLevelTwo();

        }
    }

    public void playLevelThree()
    {
        if (uiSound)
        {
            uiSound.playLevelThree();
        }
    }
}
