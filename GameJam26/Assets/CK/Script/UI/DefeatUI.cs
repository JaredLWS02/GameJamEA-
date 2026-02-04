using UnityEngine;
using UnityEngine.SceneManagement;

public class DefeatUI : MonoBehaviour
{
    public static bool GameIsDefeat = false;

    public GameObject DefeatMenuUI;


    public void Restart()
    {
        DefeatMenuUI.SetActive(false);
        Time.timeScale = 1f;
        // Reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void isDefeat()
    {
        DefeatMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsDefeat = true;
        Debug.Log("U lose");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

}
