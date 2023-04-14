using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMenu : MonoBehaviour
{
    public PlasmaPistol plasmaPistol;
    public Inventory inventory;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPlasmaPistol()
    {
        inventory.AddWeapon(plasmaPistol);
    }
}
