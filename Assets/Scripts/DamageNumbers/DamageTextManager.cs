using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageTextManager : MonoBehaviour
{
    public GameObject damageTextPrefab, enemyInstance;
    public string textToDisplay;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject DamageText = Instantiate(damageTextPrefab, enemyInstance.transform);
            DamageText.transform.GetChild(0).GetComponent<TextMeshPro>().SetText(textToDisplay);
        }
    }
}
