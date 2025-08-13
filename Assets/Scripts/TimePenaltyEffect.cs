using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimePenaltyEffect : MonoBehaviour
{
    public TextMeshProUGUI penaltyText;
    public float floatDistance = 50f;
    public float fadeDuration = 0.8f;

    private Vector3 startPosition;

    void Awake()
    {
        startPosition = penaltyText.rectTransform.anchoredPosition;
        penaltyText.gameObject.SetActive(false);
    }

    public void ShowPenalty()
    {
        penaltyText.rectTransform.anchoredPosition = startPosition;
        penaltyText.alpha = 1f;
        penaltyText.gameObject.SetActive(true);
        StartCoroutine(FloatAndFade());
    }

    System.Collections.IEnumerator FloatAndFade()
    {
        float elapsed = 0f;
        Vector3 endPos = startPosition + Vector3.down * floatDistance;

        while (elapsed < fadeDuration)
        {
            float t = elapsed / fadeDuration;

            // Yukar�dan a�a�� yava��a iner
            penaltyText.rectTransform.anchoredPosition = Vector3.Lerp(startPosition, endPos, t);

            // �effafla��r
            penaltyText.alpha = 1f - t;

            elapsed += Time.deltaTime;
            yield return null;
        }

        penaltyText.gameObject.SetActive(false);
    }
}
