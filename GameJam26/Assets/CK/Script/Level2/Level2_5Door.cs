using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2_5Door : MonoBehaviour
{
    [SerializeField] public SpriteRenderer sr;
    [SerializeField] public SpriteRenderer sr2;

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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr.enabled = true;
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
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Debug.Log("hh u wrong");
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
