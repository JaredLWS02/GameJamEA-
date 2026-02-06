using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ActivateButtonAfterMusic : MonoBehaviour
{
    public UnityEngine.UI.Button nextButton;

    void Awake()
    {
        nextButton.gameObject.SetActive(false);
    }

    public void WaitForEvent()
    {

        StopAllCoroutines();
        StartCoroutine(WaitThenShow(10f));
    }

    IEnumerator WaitThenShow(float duration)
    {
        yield return new WaitForSecondsRealtime(duration);
        nextButton.gameObject.SetActive(true);
    }

    public void home()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("Cat");
    }
}

