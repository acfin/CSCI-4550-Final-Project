using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CullWall : MonoBehaviour
{
    [SerializeField] MeshRenderer[] wallMeshes;
    private float fadedAlpha = 0.2f; // Set the desired alpha value for the faded effect
    BoxCollider floor;

    void Start()
    {
        floor = GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.name == "Player")
        {
            SetWallTransparency(fadedAlpha, true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.name == "Player")
        {
            SetWallTransparency(1f, false);
        }
    }
    
    // Changes the Wall transparency when the player is in front of it, sets back to alpha when not in front.
    void SetWallTransparency(float alpha, bool transparent)
    {
        foreach (MeshRenderer wall in wallMeshes)
        {
            Color baseColor = wall.material.GetColor("_BaseColor");
            baseColor.a = alpha;
            wall.material.SetColor("_BaseColor", baseColor);

            if (transparent)
            {
                wall.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                wall.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.One);
                wall.material.SetInt("_ZWrite", 0);
                wall.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                wall.material.renderQueue = 3000;
            }
            else
            {
                wall.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
                wall.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.Zero);
                wall.material.SetInt("_ZWrite", 1);
                wall.material.renderQueue = -1;
            }
        }
    }
}