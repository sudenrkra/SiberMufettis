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
            hearts[health].SetActive(false); // Sa�dan sola kalpleri sil
        }

        if (health <= 0)
        {
            PlayerPrefs.SetInt("FinalScore", FindObjectOfType<ScoreManager>().GetScore());
            PlayerPrefs.SetString("GameOverReason", "T�m canlar�n� kaybettin");
            SoundManager.instance.PlayGameOver(); // ses �nce
            SceneManager.LoadScene("EndScene");   // sonra sahne ge�i�i
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
