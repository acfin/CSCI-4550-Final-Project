using System;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStats : MonoBehaviour
{
    public int level = 1;
    public int experience = 0;
    public int GetExperienceToLevelUp(int currentLevel) => 100 + (int)((currentLevel - 1) * 150);

    public UnityEvent OnLevelUp;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            AddExperience(25);
        }
    }

    public void AddExperience(int exp)
    {
        experience += exp;

        if (experience >= GetExperienceToLevelUp(level))
        {
            experience -= GetExperienceToLevelUp(level);
            level++;

            if (OnLevelUp != null)
            {
                OnLevelUp.Invoke();
            }
        }
    }
}