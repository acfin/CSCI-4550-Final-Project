using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelUp : MonoBehaviour
{
    public GameObject levelUpPanel;
    public Button[] optionButtons;
    public List<Weapon> weaponList;
    public List<Passive> passiveList;
    public Inventory inventory;

    private void Start()
    {
        levelUpPanel.SetActive(false);

        PlayerStats playerStats = GetComponent<PlayerStats>();
        if (playerStats != null)
        {
            playerStats.OnLevelUp.AddListener(ShowLevelUpOptions);
        }
    }

    private List<Object> GetAvailableOptions()
    {
        List<Object> options = new List<Object>(weaponList.Count + passiveList.Count);

        List<Weapon> filteredWeaponList = weaponList.FindAll(weapon => !inventory.IsWeaponAtMaxLevel(weapon));
        List<Passive> filteredPassiveList = passiveList.FindAll(passive => !inventory.IsPassiveAtMaxLevel(passive));

        if (inventory.GetWeapons().Count >= inventory.weaponCapacity)
        {
            options.AddRange(filteredWeaponList.FindAll(weapon => inventory.ContainsWeapon(weapon)));
        }
        else
        {
            options.AddRange(filteredWeaponList);
        }

        if (inventory.GetPassives().Count >= inventory.passiveCapacity)
        {
            options.AddRange(filteredPassiveList.FindAll(passive => inventory.ContainsPassive(passive)));
        }
        else
        {
            options.AddRange(filteredPassiveList);
        }

        return options;
    }


    public void ShowLevelUpOptions()
    {
        // Do not show level up options if all items are at max level
        if (inventory.AreAllItemsAtMaxLevel())
        {
            return;
        }
        levelUpPanel.SetActive(true);
        Time.timeScale = 0f;

        List<Object> options = GetAvailableOptions();

        // If there are fewer options than buttons, disable the extra buttons
        if (options.Count < optionButtons.Length)
        {
            for (int i = options.Count; i < optionButtons.Length; i++)
            {
                optionButtons[i].gameObject.SetActive(false);
            }
        }

        int loopCount = Mathf.Min(options.Count, optionButtons.Length);
        for (int i = 0; i < loopCount; i++)
        {
            int randomIndex = Random.Range(0, options.Count);
            Object randomOption = options[randomIndex];
            options.RemoveAt(randomIndex);

            TextMeshProUGUI buttonText = optionButtons[i].GetComponentInChildren<TextMeshProUGUI>();

            if (randomOption is Weapon weapon)
            {
                buttonText.text = weapon.weaponName;
                optionButtons[i].onClick.AddListener(() => SelectOption(weapon));
            }
            else if (randomOption is Passive passive)
            {
                buttonText.text = passive.passiveName;
                optionButtons[i].onClick.AddListener(() => SelectOption(passive));
            }
        }
    }


    public void SelectOption(Object option)
    {
        if (option is Weapon weapon)
        {
            inventory.AddWeapon(weapon);
        }
        else if (option is Passive passive)
        {
            inventory.AddPassive(passive);
        }

        levelUpPanel.SetActive(false);
        Time.timeScale = 1f;

        foreach (Button button in optionButtons)
        {
            button.onClick.RemoveAllListeners();
        }
    }
}
