using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Button : MonoBehaviour
{
    public string LevelNameFail;
    public string LevelNameCorrect;
    private bool playerInside;
    public bool isCorrectButton;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            LoadLevel();
        }
    }

    void LoadLevel()
    {
        if (isCorrectButton)
        {
            SceneManager.LoadScene(LevelNameCorrect);
        }
        else
        {
            SceneManager.LoadScene(LevelNameFail);
        }
    }


}
