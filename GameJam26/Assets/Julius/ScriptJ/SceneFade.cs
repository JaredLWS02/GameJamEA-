using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneFade : MonoBehaviour
{
    public Image fadeImage;       // Assign the full-screen black UI Image
    public float fadeDuration = 1f;
    private AudioManager audioManager;
    private void Awake()
    {
        Time.timeScale = 1f; // 🔥 force unpause on scene load
        // Start fully black at first
        Color c = fadeImage.color;
        c.a = 1f;
        fadeImage.color = c;
    }

    private void Start()
    {
        // Fade from black to transparent on scene load
        audioManager = GameObject.FindGameObjectWithTag("audioManager").GetComponent<AudioManager>();
        StartCoroutine(FadeIn());
    }

    public void NextScene()
    {
        Time.timeScale = 1f; // 🔥 force unpause on scene load
        StartCoroutine(FadeOutAndLoadNext());
    }

    // Call this to restart the scene with fade
    public void RestartScene()
    {
        StartCoroutine(FadeOutAndRestart());
    }

    private IEnumerator FadeIn()
    {
        float timer = 0f;
        Color c = fadeImage.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            c.a = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            fadeImage.color = c;
            yield return null;
        }

        c.a = 0f;
        fadeImage.color = c;
    }

    private IEnumerator FadeOutAndRestart()
    {
        float timer = 0f;
        Color c = fadeImage.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            c.a = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            fadeImage.color = c;
            yield return null;
        }

        c.a = 1f;
        fadeImage.color = c;

        // Reload scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // New: Fade out then load next scene
    private IEnumerator FadeOutAndLoadNext()
    {
        float timer = 0f;
        Color c = fadeImage.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            c.a = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            fadeImage.color = c;
            yield return null;
        }

        c.a = 1f;
        fadeImage.color = c;

        // Load next scene by build index
        Scene currentScene = SceneManager.GetActiveScene();
        int nextSceneIndex = currentScene.buildIndex + 1;


        Time.timeScale = 1f;
        audioManager.PauseBGM(audioManager.winBGM);
        SceneManager.LoadScene("cat");
    }

    
}
