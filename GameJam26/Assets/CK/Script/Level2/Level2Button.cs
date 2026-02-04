using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Button : MonoBehaviour
{
    public string CorrectlevelName;
    public string WronglevelName;
    public bool CorrentButton = false;
    private bool playerInside = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            Debug.Log("Player entered");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            
        }
    }


    void Update()
    {
        if (playerInside && Input.GetKeyDown(KeyCode.E))
        {
            LoadLevel();
        }
    }

    void LoadLevel()
    {
        if (CorrentButton)
        {
            SceneManager.LoadScene(CorrectlevelName);

        }
        else if(!CorrentButton)
        {
            SceneManager.LoadScene(WronglevelName);
        }
    }
}
