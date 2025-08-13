using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppTrigger : MonoBehaviour
{
    public GameObject paperUI;

    void OnMouseDown()
    {
        if (paperUI != null)
        {
            paperUI.SetActive(true);
            SoundManager.instance.PlayPaperOpen();
        }
    }
}
