using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource audioSource;
    public AudioClip correctSound, wrongSound, penaltySound, winSound, loseSound;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void PlayCorrect() => audioSource.PlayOneShot(correctSound);
    public void PlayWrong() => audioSource.PlayOneShot(wrongSound);
    public void PlayPenalty() => audioSource.PlayOneShot(penaltySound);
    public void PlayWin() => audioSource.PlayOneShot(winSound);
    public void PlayLose() => audioSource.PlayOneShot(loseSound);
}
