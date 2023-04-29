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
        uiSound.playLevelOne();
    }

    public void playLevelTwo()
    {
        uiSound.playLevelTwo();
    }

    public void playLevelThree()
    {
        uiSound.playLevelThree();
    }
}
