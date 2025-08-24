using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    public float totalTime = 60f; 
    private float currentTime;
    public float remainingTime = 60f;
    public ScoreManager scoreManager;

    public TextMeshProUGUI timerText;

    private bool isGameOver = false;

    public GameObject redFlashImage;

    void Start()
    {
        currentTime = totalTime;
    }

    void Update()
    {
        if (isGameOver) return;

        currentTime -= Time.deltaTime;
        currentTime = Mathf.Clamp(currentTime, 0, totalTime);

        int seconds = Mathf.FloorToInt(currentTime);
        timerText.text = " " + seconds + " sn";

        if (remainingTime < 10) 
        {
            timerText.color = Color.red; 
        }

        remainingTime -= Time.deltaTime;

            
            timerText.text = " " + Mathf.Ceil(remainingTime).ToString();

            
            if (remainingTime < 10)
            {
                timerText.color = Color.red; 
            }

        if (currentTime <= 0)
        {
            PlayerPrefs.SetInt("FinalScore", FindObjectOfType<ScoreManager>().GetScore());
            PlayerPrefs.SetString("GameOverReason", "Süre doldu");
            SoundManager.instance.PlayGameOver(); 
            SceneManager.LoadScene("EndScene");   
        }
    }

    public void DecreaseTime(float amount)
    {
        currentTime -= amount;
        if (currentTime <= 0)
        {
            GameOver();
        }
        StartCoroutine(FlashRed());

        FindObjectOfType<TimePenaltyEffect>().ShowPenalty();
    }
    IEnumerator FlashRed()
    {
        redFlashImage.SetActive(true);
        yield return new WaitForSeconds(0.4f);
        redFlashImage.SetActive(false);
    }

    void GameOver()
    {
        isGameOver = true;
        SceneManager.LoadScene("EndScene"); 
    }

}
