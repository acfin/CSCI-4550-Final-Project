using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Karl : Enemy
{
    public float rotationSpeed = 45f;
    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        //RotateConstantly();
    }

    private void RotateConstantly()
    {
        float angle = rotationSpeed * Time.deltaTime;
        Transform children = GetComponentInChildren<Transform>();
        children.Rotate(angle, 0, angle * 1.5f);
    }
}
