using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupClose : MonoBehaviour
{
    public GameObject detailsPopupPanel; // Paneli Inspector'dan ba�layaca��z
    public Button closeButton; // Kapat butonu

    void Start()
    {
        // Butonun t�klanma olay�na paneli kapatma fonksiyonunu ekle
        if (closeButton != null)
            closeButton.onClick.AddListener(HidePopup);
    }

    void HidePopup()
    {
        detailsPopupPanel.SetActive(false); // Paneli gizle
    }
}
