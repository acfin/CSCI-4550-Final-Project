using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageTextManager : MonoBehaviour
{
    public GameObject damageTextPrefab;
    public Color textColor;
    public Color healColor;
    
    public void DisplayDamage(int damage)
    {
        // Random Position to prevent number overlapping
        Vector3 randomPos = new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y + 1.5f, transform.position.z);
        GameObject DamageText = Instantiate(damageTextPrefab, randomPos, Quaternion.Euler(0f, 0f, 0f));
        DamageText.transform.GetChild(0).GetComponent<TextMeshPro>().SetText(damage.ToString());
        DamageText.transform.GetChild(0).GetComponent<TextMeshPro>().faceColor = textColor;
    }

    public void DisplayHealing(int healAmount)
    {
        // Random Position to prevent number overlapping
        Vector3 randomPos = new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y + 1.5f, transform.position.z);
        GameObject HealText = Instantiate(damageTextPrefab, randomPos, Quaternion.Euler(0f, 0f, 0f));
        HealText.transform.GetChild(0).GetComponent<TextMeshPro>().SetText(healAmount.ToString());
        HealText.transform.GetChild(0).GetComponent<TextMeshPro>().faceColor = textColor;
    }
}
