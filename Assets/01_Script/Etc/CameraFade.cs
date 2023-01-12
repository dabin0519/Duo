using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFade : MonoBehaviour
{
    public Image fadeImage;
    public float fadeTime;
    public float fadeAlpha = 0.7f;

    private float time = 0;

    public void Fade()
    {
        StartCoroutine(FadeFlow());
    }

    IEnumerator FadeFlow()
    {
        fadeImage.gameObject.SetActive(true);
        Color alpha = fadeImage.color;
        while (alpha.a < fadeAlpha)
        {
            time += Time.deltaTime / fadeTime;
            alpha.a = Mathf.Lerp(0, fadeAlpha, time);
            fadeImage.color = alpha;
            yield return null;
        }
        yield return null;
    }
}
