using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 20f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            transform.position = player.transform.position + offset;
        }
        float scrollInput = Input.GetAxis("Mouse ScrollWheel");
        if (scrollInput != 0f)
        {
            float newZoom = Mathf.Clamp(offset.magnitude - scrollInput * zoomSpeed, minZoom, maxZoom);
            offset = offset.normalized * newZoom;
        }

        if (Input.GetKey(KeyCode.PageUp))
        {
            float newZoom = Mathf.Clamp(offset.magnitude - (zoomSpeed * Time.deltaTime * 5f), minZoom, maxZoom);
            offset = offset.normalized * newZoom;
        }
        else if (Input.GetKey(KeyCode.PageDown))
        {
            float newZoom = Mathf.Clamp(offset.magnitude + (zoomSpeed * Time.deltaTime * 5f), minZoom, maxZoom);
            offset = offset.normalized * newZoom;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            transform.RotateAround(player.transform.position, Vector3.up, 90);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            transform.RotateAround(player.transform.position, Vector3.up, -90);
        }

    }
}
