using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupClose : MonoBehaviour
{
    public GameObject detailsPopupPanel;
    public Button closeButton; 

    void Start()
    {
      
        if (closeButton != null)
            closeButton.onClick.AddListener(HidePopup);
    }

    void HidePopup()
    {
        detailsPopupPanel.SetActive(false); 
    }
}
