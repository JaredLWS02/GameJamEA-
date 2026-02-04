using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject panel;
    public GameObject catAni;
    public GameObject pauseMenuUI;
    private Animator animator;  

    void Start()
    {
        pauseMenuUI.SetActive(false);
        animator = catAni.GetComponent<Animator>();
        animator.enabled = false;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (panel.activeSelf)
            {
                payRespect();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void payRespect()
    {
        animator.enabled = true;
    }
        
    public void closePanel()
        {
            panel.SetActive(false);
        }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}