using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    private Vector3 startPos;
    public float moveAmount = 50f; 
    public float speed = 2f; 

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        float offsetZ = Mathf.Sin(Time.time * speed) * moveAmount; 
        transform.localPosition = startPos + new Vector3(0, 0, offsetZ);

        float scaleFactor = 1 + Mathf.Sin(Time.time * speed) * 0.1f;
        transform.localScale = new Vector3(scaleFactor, scaleFactor, 1);

    }
}
