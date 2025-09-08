using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFader : MonoBehaviour
{
    public static ScreenFader Instance;

    [SerializeField] private Image fadeImage;
    [SerializeField] private float fadeDuration = 0.5f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        fadeImage.gameObject.SetActive(true);
        Color c = fadeImage.color;
        c.a = 0;
        fadeImage.color = c;
    }

    public IEnumerator FadeTransition(System.Action onMidFade)
    {
        yield return StartCoroutine(FadeOut());
        onMidFade?.Invoke();
        yield return StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float t = 0;
        Color c = fadeImage.color;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(1, 0, t / fadeDuration);
            fadeImage.color = c;
            yield return null;
        }
        fadeImage.raycastTarget = false;
    }

    private IEnumerator FadeOut()
    {
        fadeImage.raycastTarget = true;
        float t = 0;
        Color c = fadeImage.color;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            c.a = Mathf.Lerp(0, 1, t / fadeDuration);
            fadeImage.color = c;
            yield return null;
        }

    }
}
