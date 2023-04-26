using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI lvlText;
    public int slotNum;

    private void Start()
    {
        ClearSlot();
    }

    private void Update()
    {
        if (icon.sprite.name != null)
        {
            icon.enabled = true;
        }
    }

    public void ClearSlot()
    {
        icon.enabled = false;
    }
}
