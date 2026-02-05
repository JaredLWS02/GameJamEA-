using UnityEngine;
using System.Collections;
public class BackgroundColor : MonoBehaviour
{
    public float speed = 0.3f;

    SpriteRenderer sr;
    Coroutine rainbowRoutine;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void StartRainbow()
    {
        if (rainbowRoutine == null)
            rainbowRoutine = StartCoroutine(Rainbow());
    }

    public void StopRainbow()
    {
        if (rainbowRoutine != null)
        {
            StopCoroutine(rainbowRoutine);
            rainbowRoutine = null;
        }
    }

    IEnumerator Rainbow()
    {
        float hue = 0f;

        while (true)
        {
            hue += Time.deltaTime * speed;
            if (hue > 1f) hue = 0f;

            sr.color = Color.HSVToRGB(hue, 1f, 1f);
            yield return null;
        }
    }
}
