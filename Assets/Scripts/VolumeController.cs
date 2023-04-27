using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class VolumeController : MonoBehaviour
{
    public static VolumeController Instance;

    public int settingsScene = 2;

    public AudioMixer mainMixer;
    public Slider masterVolumeSlider;
    public Slider musicVolumeSlider;
    public Slider soundVolumeSlider;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            if (SceneManager.GetActiveScene().buildIndex == settingsScene)
            {
                Destroy(Instance.gameObject);
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateSliders();
    }

    private void Start()
    {
        UpdateSliders();
    }

    private void UpdateSliders()
    {
        if (masterVolumeSlider != null)
        {
            masterVolumeSlider.onValueChanged.RemoveAllListeners();
            masterVolumeSlider.onValueChanged.AddListener(SetMasterVolume);
            masterVolumeSlider.value = PlayerPrefs.GetFloat("Master", 0.75f);
        }

        if (musicVolumeSlider != null)
        {
            musicVolumeSlider.onValueChanged.RemoveAllListeners();
            musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
            musicVolumeSlider.value = PlayerPrefs.GetFloat("Music", 0.75f);
        }

        if (soundVolumeSlider != null)
        {
            soundVolumeSlider.onValueChanged.RemoveAllListeners();
            soundVolumeSlider.onValueChanged.AddListener(SetSoundVolume);
            soundVolumeSlider.value = PlayerPrefs.GetFloat("Sound", 0.75f);
        }
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
