using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxOpener : MonoBehaviour
{
    public GameObject openedBoxPrefab;
 
    void OnMouseDown()
    {
        Instantiate(openedBoxPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
