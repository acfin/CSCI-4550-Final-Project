using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpin : MonoBehaviour
{
    public float rotationSpeed = 360.0f;
    void Update()
    {
        // Rotate the pickup.
        float rotationAmount = rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotationAmount, 0);
    }
}
