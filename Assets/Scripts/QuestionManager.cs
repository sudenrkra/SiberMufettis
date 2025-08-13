using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestionManager : MonoBehaviour
{
    public GameObject darkOverlay;
    public GameObject detailsPopupPanel;
    public TextMeshProUGUI popupDetailsText;
    public Button closeButton;

    public HealthManager healthManager;
    public ScoreManager scoreManager;

    public TextMeshProUGUI appNameText;
    public TextMeshProUGUI permissionText;
    public TextMeshProUGUI descriptionText;
    public Image iconImage;

    // public TextMeshProUGUI detailsText; 

    private List<AppData> appList;
    private List<string> displayedAppNames = new List<string>();
    private AppData currentApp;

    void Start()
    {
        LoadApps();
        ShowRandomApp();

        if (closeButton != null)
            closeButton.onClick.AddListener(CloseDetailsPanel);
    }

    void LoadApps()
    {
        TextAsset jsonText = Resources.Load<TextAsset>("apps");

        if (jsonText != null)
        {
            string wrapped = "{\"apps\":" + jsonText.text + "}";
            AppListWrapper wrapper = JsonUtility.FromJson<AppListWrapper>(wrapped);
            appList = wrapper.apps;
        }
        else
        {
            Debug.LogError("apps.json dosyas� bulunamad�!");
        }
    }

    public void ShowDetailsPanel()
    {
        darkOverlay.SetActive(true);
        detailsPopupPanel.SetActive(true);
        popupDetailsText.text = currentApp.details;
        
    }
    public void CloseDetailsPanel()
    {
        detailsPopupPanel.SetActive(false);
        darkOverlay.SetActive(false);
    }


    public void ShowRandomApp()
    {
        if (appList == null || appList.Count == 0) return;

        // Geriye kalan g�sterilmemi� uygulamalar� filtrele
        List<AppData> remainingApps = appList.FindAll(app => !displayedAppNames.Contains(app.appName));

        if (remainingApps.Count == 0)
        {
            Debug.Log("T�m uygulamalar g�sterildi.");
            // Burada istersen oyunu bitir veya uygulama listesini s�f�rla
            return;
        }

        // Rastgele bir uygulama se�
        currentApp = remainingApps[Random.Range(0, remainingApps.Count)];

        // G�sterildi olarak i�aretle
        displayedAppNames.Add(currentApp.appName);

        // UI g�ncelle
        appNameText.text = currentApp.appName;
        permissionText.text = "�zin: " + currentApp.permission;
        descriptionText.text = currentApp.description;

        Sprite iconSprite = Resources.Load<Sprite>("png/" + currentApp.icon);
        iconImage.sprite = iconSprite;

        if (iconSprite == null)
        {
            Debug.LogWarning("�kon y�klenemedi: " + currentApp.icon);
        }
    }

    private class AppListWrapper
    {
        public List<AppData> apps;
    }

    public void OnAllowClicked()
    {
        if (currentApp != null)
        {
            if (currentApp.isSafe)
            {
                scoreManager.AddScore(10);
                SoundManager.instance.PlayCorrect(); // ? Do�ruysa ding
            }
            else
            {
                healthManager.DecreaseHealth();
                SoundManager.instance.PlayWrong();   // ? Yanl��sa buzz
            }

            ShowRandomApp();
        }
    }
    public void OnDenyClicked()
    {
        if (currentApp != null)
        {
            if (!currentApp.isSafe)
            {
                scoreManager.AddScore(10);
                SoundManager.instance.PlayCorrect(); // ? Do�ruysa ding
            }
            else
            {
                healthManager.DecreaseHealth();
                SoundManager.instance.PlayWrong();   // ? Yanl��sa buzz
            }

            ShowRandomApp();
        }
    }

}
