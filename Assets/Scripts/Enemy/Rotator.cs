using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotationSpeed = 45f;
    private float angle;
    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        angle = rotationSpeed * Time.deltaTime;  
        transform.Rotate(angle, 0, angle * 1.5f);
    }
}
