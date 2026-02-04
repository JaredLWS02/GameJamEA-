using UnityEngine;

public class Level2_5Button : MonoBehaviour
{
    public Button2_5ButtonManger manager;

    private bool playerInside = false;
    private bool isPressed = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInside = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInside = false;
    }

    void Update()
    {
        if (!playerInside || isPressed) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            isPressed = true;
            manager.ButtonPressed();
            Debug.Log(gameObject.name + " pressed");
        }
    }

    public void ResetButton()
    {
        isPressed = false;
    }
}
