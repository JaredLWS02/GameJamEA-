using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Door : MonoBehaviour
{
    public Button2_5ButtonManger manager;
    public string nextLevelName;

    private bool playerInside = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInside = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInside = false;
    }

    void Update()
    {
        if (!playerInside) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            // CONDITION 0: No button pressed
            if (manager.pressedCount == 0)
            {
                Debug.Log("locked");
            }
            // CONDITION 1: One button pressed
            else if (manager.pressedCount == 1)
            {
                Debug.Log("hh u lose");
            }
            // CONDITION 2: Two buttons pressed in time
            else if (manager.isBothPressed)
            {
                Debug.Log("Success! Go next level");
                SceneManager.LoadScene(nextLevelName);
            }
        }
    }
}
