using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource audioSource;

    public AudioClip correctSound;
    public AudioClip wrongSound;
    public AudioClip winSound;
    public AudioClip gameOverSound;
    public AudioClip paperOpenSound;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void PlayCorrect()
    {
        audioSource.PlayOneShot(correctSound);
    }

    public void PlayWrong()
    {
        audioSource.PlayOneShot(wrongSound);
    }

    public void PlayGameOver()
    {
        audioSource.PlayOneShot(gameOverSound);
    }
    public void PlayWin()
    {
        audioSource.PlayOneShot(winSound);
    }
    public void PlayPaperOpen()
    {
        audioSource.PlayOneShot(paperOpenSound);
    }
}
