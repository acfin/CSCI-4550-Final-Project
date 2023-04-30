using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullWall : MonoBehaviour
{
    [SerializeField] MeshRenderer[] wallMeshes;
    BoxCollider floor;
    bool isCulled = false;
    void Start()
    {
        floor = GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.name == "Player")
        {
            CullWalls();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.name == "Player")
        {
            UncullWalls();
        }
    }

    void CullWalls()
    {
        foreach(MeshRenderer wall in wallMeshes)
        {
            wall.forceRenderingOff = true;
        }
    }

    void UncullWalls()
    {
        foreach (MeshRenderer wall in wallMeshes)
        {
            wall.forceRenderingOff = false;
        }
    }
}
