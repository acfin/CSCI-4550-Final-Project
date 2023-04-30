using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class UISoundInterface : MonoBehaviour
{
    UISound uiSound;

    void Start()
    {
        // Null reference check if loaded scene is any scene other than MainMenu
        GameObject uiSoundPlayer = GameObject.Find("UISoundPlayer");
        if (uiSoundPlayer != null)
        {
            uiSound = uiSoundPlayer.GetComponent<UISound>();
        }
        else
        {
            Debug.LogWarning("UISoundPlayer not found.");
        }
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
