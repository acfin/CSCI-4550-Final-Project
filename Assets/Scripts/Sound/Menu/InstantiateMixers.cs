using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class InstantiateMixers : MonoBehaviour
{
    public AudioMixer mainMixer;
    // Start is called before the first frame update
    void Start()
    {
        SetMasterVolume(PlayerPrefs.GetFloat("Master", 0.75f));
        SetMusicVolume(PlayerPrefs.GetFloat("Music", 0.75f));
        SetSoundVolume(PlayerPrefs.GetFloat("Sound", 0.75f));
    }

    public void SetMasterVolume(float volume)
    {
        float dB = volume > 0 ? Mathf.Log10(volume) * 20 : -80;
        mainMixer.SetFloat("Master", dB);
        PlayerPrefs.SetFloat("Master", volume);
    }

    public void SetMusicVolume(float volume)
    {
        float dB = volume > 0 ? Mathf.Log10(volume) * 20 : -80;
        mainMixer.SetFloat("Music", dB);
        PlayerPrefs.SetFloat("Music", volume);
    }

    public void SetSoundVolume(float volume)
    {
        float dB = volume > 0 ? Mathf.Log10(volume) * 20 : -80;
        mainMixer.SetFloat("Sound", dB);
        PlayerPrefs.SetFloat("Sound", volume);
    }
}
