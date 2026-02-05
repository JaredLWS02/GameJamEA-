using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool isGamePause;
    public GameObject PauseMenuUI;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePause)
            {
                Resume();
            }
            else
            {
                PauseGame();
            }
        }
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePause = false;
    }
    public void PauseGame()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePause = true;
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
