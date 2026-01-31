using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public void playgame()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void setting()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void mainmenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void exitgame()
    {
        Application.Quit();
    }
}
