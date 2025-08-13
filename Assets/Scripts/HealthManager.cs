using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public GameObject[] hearts; // Kalp image objeleri (UI objeleri)
    private int health = 3;
    public ScoreManager scoreManager;

    public void DecreaseHealth()
    {
        health--;

        if (health >= 0 && health < hearts.Length)
        {
            hearts[health].SetActive(false); // Saðdan sola kalpleri sil
        }

        if (health <= 0)
        {
            PlayerPrefs.SetInt("FinalScore", FindObjectOfType<ScoreManager>().GetScore());
            PlayerPrefs.SetString("GameOverReason", "Tüm canlarýný kaybettin");
            SoundManager.instance.PlayGameOver(); // ses önce
            SceneManager.LoadScene("EndScene");   // sonra sahne geçiþi
        }
    }

    public void ResetHealth()
    {
        health = 3;

        foreach (GameObject heart in hearts)
        {
            heart.SetActive(true);
        }
    }
}
