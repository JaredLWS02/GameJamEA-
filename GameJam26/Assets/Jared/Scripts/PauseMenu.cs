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
    public MonoBehaviour playerMove;
    public bool spin = false;
    [SerializeField] private AudioSource aud;

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

        if (panel.activeSelf)
        {
            playerMove.enabled = false;
            if (Input.GetKeyDown(KeyCode.F))
            {   
                spin = true;
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
        aud.enabled = true;
    }
        
    public void closePanel()
    {
            panel.SetActive(false);
            playerMove.enabled = true;
            aud.enabled = false;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}