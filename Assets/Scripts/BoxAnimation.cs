using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private Vector3 startPos;
    public float moveAmount = 0.1f;
    public float speed = 2f;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float offsetY = Mathf.Sin(Time.time * speed) * moveAmount;
        transform.position = startPos + new Vector3(0, offsetY, 0);
    }
}
