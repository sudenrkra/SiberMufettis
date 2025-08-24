using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;

    private void Start()
    {
        finalScoreText.text = " " + ScoreManager.instance.GetScore(); 
    }
}
