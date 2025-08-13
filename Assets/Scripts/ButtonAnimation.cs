using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimation : MonoBehaviour
{
    private Vector3 startPos;
    public float moveAmount = 50f; // Butonun ne kadar ileri-geri gideceði
    public float speed = 2f; // Hareket hýzý

    void Start()
    {
        startPos = transform.localPosition; // Baþlangýç pozisyonunu kaydet
    }

    void Update()
    {
        float offsetZ = Mathf.Sin(Time.time * speed) * moveAmount; // Z ekseninde ileri-geri hareket
        transform.localPosition = startPos + new Vector3(0, 0, offsetZ);

        float scaleFactor = 1 + Mathf.Sin(Time.time * speed) * 0.1f;
        transform.localScale = new Vector3(scaleFactor, scaleFactor, 1);

    }
}
