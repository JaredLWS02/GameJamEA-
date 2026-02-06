using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class mainMenu : MonoBehaviour
{
    public string sceneName;
    [SerializeField] private Image bg;
    [SerializeField] private Image img1;
    [SerializeField] private Image img2;

    public void StartGame()
    {
        StartCoroutine(flash());
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    private IEnumerator flash()
    {
        bg.enabled = true;
        yield return new WaitForSeconds(0.5f);
        img1.enabled = true;
        yield return new WaitForSeconds(3);
        img1.enabled = false;
        img2.enabled = true;
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(sceneName);
        img2.enabled = false;
        bg.enabled = false;
    }
}
