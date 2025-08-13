using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndSceneManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI reasonText;

    void Start()
    {
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0);
        string reason = PlayerPrefs.GetString("GameOverReason", "Bilinmeyen neden");

        scoreText.text = "Skorun: " + finalScore;
        reasonText.text = reason;
    }
}
