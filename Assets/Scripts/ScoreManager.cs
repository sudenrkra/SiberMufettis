using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public GameObject paperPanel;

    public GameObject winPanel; // Inspector'dan atayacaðýz
    public int winScore = 100;

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();

        if (score >= winScore)
        {
            WinGame();
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // ScoreManager sahne deðiþince yok olmasýn
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        scoreText.text = "" + score;
    }

    public int GetScore()
    {
        return score;
    }

    void WinGame()
    {
        Time.timeScale = 0f; // Oyunu durdur
        SceneManager.LoadScene("EndScene");  // Kazanma panelini göster

        if (paperPanel != null)
        {
            paperPanel.SetActive(false); // Kaðýdý gizle
        }
        SoundManager.instance.PlayWin();
    }
}
