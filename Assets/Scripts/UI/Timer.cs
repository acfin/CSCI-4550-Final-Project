using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText;
    public float secondsCount;
    public int minuteCount;
    public int hourCount;

    private void Start()
    {
        hourCount = 0;
    }
    void Update()
    {
        UpdateTimerUI();
    }
    //call this on update
    public void UpdateTimerUI()
    {
        //set timer UI
        secondsCount += Time.deltaTime;
        timerText.text = null;

        if (hourCount != 0)
        {
            timerText.text = hourCount + ":";
        }
        if (secondsCount < 10)
        {
            timerText.text = timerText.text + minuteCount + ":0" + (int)secondsCount;
        }
        else
        {
            timerText.text = timerText.text + minuteCount + ":" + (int)secondsCount;
        }

        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
        else if (minuteCount >= 60)
        {
            hourCount++;
            minuteCount = 0;
        }
    }
}
