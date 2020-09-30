using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeAlpha : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDuration;

    void Awake()
    {
        if (!canvasGroup)
        {
            canvasGroup = GetComponentInChildren<CanvasGroup>();
        }
    }

    public void FadeIn(float fromAlpha)
    {
        canvasGroup.alpha = fromAlpha;
        StartCoroutine(FadeToInSeconds(1f, fadeDuration));
    }
    public void FadeIn()
    {
        StartCoroutine(FadeToInSeconds(1f, fadeDuration));
    }

    public void FadeOut()
    {
        StartCoroutine(FadeToInSeconds(1f, fadeDuration));
    }

    private IEnumerator FadeToInSeconds(float targetAlpha, float seconds)
    {
        var previousAlpha = canvasGroup.alpha;
        var timePast = 0f;

        while (timePast < seconds)
        {
            timePast += Time.unscaledDeltaTime;
            canvasGroup.alpha = Mathf.Lerp(previousAlpha, targetAlpha, timePast / seconds);
            yield return null;
        }
    }
}
