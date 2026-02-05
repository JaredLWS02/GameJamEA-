using UnityEngine;
using UnityEngine.SceneManagement;

public class openLevel : MonoBehaviour
{
    public GameObject Catpanel;
    public GameObject interactables;
    public MonoBehaviour playerMovement;
    private bool playerInTrigger = false;
    [SerializeField] private AudioSource aud;
    [SerializeField] private PauseMenu pan;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInTrigger)
        {
            // If panel is closed and interactables is inactive, show the interact prompt again
            if (!Catpanel.activeSelf && (interactables != null) && !interactables.activeSelf)
            {
                interactables.SetActive(true);
            }

            // Handle opening/closing the panel on E press (toggle)
            if (Input.GetKeyDown(KeyCode.E))
            {
                bool isActive = Catpanel.activeSelf;
                Catpanel.SetActive(!isActive);
                interactables.SetActive(isActive); // Hide interactables if panel opens, show if closes
                if (!isActive && pan.spin)
                {
                    aud.enabled = true;
                }
                if(isActive)
                {
                    aud.enabled = false;
                }
                if (!playerMovement.enabled)
                {
                    playerMovement.enabled = true;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            playerInTrigger = true;
            if (interactables != null && !Catpanel.activeSelf)
            {
                interactables.SetActive(true);
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            playerInTrigger = false;
            if (interactables != null)
            {
                interactables.SetActive(false);
            }
        }
    }
}
