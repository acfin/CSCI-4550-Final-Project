using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveHUD : MonoBehaviour
{
    public Slider slider;
    public float secondsCount;
    public int waveLength;

    void Update()
    {
        UpdateTimerUI();
        if (slider.maxValue != waveLength)
        {
            slider.maxValue = waveLength;
        }
    }

    public void UpdateTimerUI()
    {
        secondsCount -= Time.deltaTime;
        slider.value = secondsCount;
    }
}
