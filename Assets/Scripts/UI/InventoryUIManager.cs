using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    public List<InventorySlot> weaponSlots = new List<InventorySlot>();
    public List<InventorySlot> passiveSlots = new List<InventorySlot>();
    private InventorySlot slot;
    public void updateWeapons(List<Weapon> weapons)
    {
        for (int i = 0; i < weapons.Count; i++){
            slot = weaponSlots[i];
            if (weapons[i] != null){
                slot.icon.enabled = true;
                slot.lvlText.enabled = true;
                slot.icon.sprite = weapons[i].icon;
                slot.lvlText.text = weapons[i].level.ToString();
            }
            else
            {
                slot.ClearSlot();
            }
        }
    }

    public void updatePassives(List<Passive> passives)
    {
        for (int i = 0; i < passives.Count; i++)
        {
            slot = passiveSlots[i];
            if (passives[i] != null)
            {
                slot.icon.enabled = true;
                slot.lvlText.enabled = true;
                slot.icon.sprite = passives[i].icon;
                slot.lvlText.text = passives[i].level.ToString();
            }
            else
            {
                slot.ClearSlot();
            }
        }
    }
}
