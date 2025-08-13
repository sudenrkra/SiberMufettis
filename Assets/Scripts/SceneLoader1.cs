using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader1 : MonoBehaviour
{
    public Button startButton; // Baþla butonu
    public Button exitButton; // Çýkýþ butonu

    void Start()
    {
        // Butonlarý otomatik olarak baðla
        if (startButton != null)
            startButton.onClick.AddListener(StartGame);

        if (exitButton != null)
            exitButton.onClick.AddListener(ExitGame);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // Oyunun sahnesine geçiþ yap
    }

    public void ExitGame()
    {
        if (Application.isEditor)
        {
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            Application.Quit();
        }
    }

}
