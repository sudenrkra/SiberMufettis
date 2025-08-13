using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform cameraStartPoint;
    public Transform cameraZoomPoint;
    public float cameraSpeed = 2f;
    private bool zooming = false;

    void Start()
    {
        // Baþlangýç konumu
        transform.position = cameraStartPoint.position;
        transform.rotation = cameraStartPoint.rotation;
    }

    void Update()
    {
        if (zooming)
        {
            // Pozisyon ve rotasyonu yavaþça hedefe kaydýr
            transform.position = Vector3.Lerp(transform.position, cameraZoomPoint.position, Time.deltaTime * cameraSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, cameraZoomPoint.rotation, Time.deltaTime * cameraSpeed);
        }
    }

    public void StartZoom()
    {
        zooming = true;
    }
}
