using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2Button : MonoBehaviour
{
    public string CorrectlevelName;
    public string WronglevelName;
    public bool CorrentButton = false;
    private bool playerInside = false;
    public GameObject UI;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            Debug.Log("Player entered");
            UI.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            UI.SetActive(false);
            
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
