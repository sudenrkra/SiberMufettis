using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTriggerZoom : MonoBehaviour
{
    public CameraController cameraController;

    void OnMouseDown()
    {
        cameraController.StartZoom();
    }
}
