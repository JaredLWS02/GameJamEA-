using UnityEngine;

public class Level2_5Button : MonoBehaviour
{
    public Button2_5ButtonManger manager;

    private bool playerInside = false;
    private bool isPressed = false;
    public GameObject UI;
    public AudioSource ButtonSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInside = true;
        UI.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInside = false;
            UI.SetActive(false);
    }

    void Update()
    {
        if (!playerInside || isPressed) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            isPressed = true;
            manager.ButtonPressed();
            ButtonSound.Play();
            Debug.Log(gameObject.name + " pressed");
        }
    }

    public void ResetButton()
    {
        isPressed = false;
    }
}
