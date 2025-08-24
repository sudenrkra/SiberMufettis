using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader1 : MonoBehaviour
{
    public Button startButton; 
    public Button exitButton; 

    void Start()
    {
        
        if (startButton != null)
            startButton.onClick.AddListener(StartGame);

        if (exitButton != null)
            exitButton.onClick.AddListener(ExitGame);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); 
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
