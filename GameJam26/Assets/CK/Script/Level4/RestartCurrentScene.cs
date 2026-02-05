using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartCurrentScene : MonoBehaviour
{

    public WinningEvent trigger;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")&& !trigger.eventTriggered)
        {
            Debug.Log("Player entered restart zone"); // Check if it's firing

            // Reset time scale
            Time.timeScale = 1f;

            // Reload the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            SceneManager.LoadScene("cat");
        }
    }
}
