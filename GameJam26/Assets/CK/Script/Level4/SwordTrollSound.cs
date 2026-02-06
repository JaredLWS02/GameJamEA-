using UnityEngine;
using System.Collections;

public class SwordTrollSound : MonoBehaviour
{
    public AudioSource audioSource;  // Assign the sound to play
    public float cooldown = 10f;     // 10 seconds cooldown

    public GameObject InteractUI;
    private bool canClick = true;
    private bool playerInside = false;
    public AudioSource playerAudio;

    void Update()
    {
        // Check if player is inside and presses E
        if (playerInside && canClick && Input.GetKeyDown(KeyCode.E))
        {
            PlaySound();
        }
    }

    private void PlaySound()
    {
        if (audioSource != null)
            audioSource.Play();
        playerAudio.Stop();
        canClick = false;                // Disable further clicks
        StartCoroutine(CooldownCoroutine());
    }

    private IEnumerator CooldownCoroutine()
    {
      
        yield return new WaitForSeconds(cooldown);
        canClick = true;
        playerAudio.Play();// Re-enable after cooldown
    }

    // Detect when player enters collision
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInside = true;
        InteractUI.SetActive(true);
    }

    // Detect when player leaves collision
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInside = false;
        InteractUI.SetActive(false);
    }
}
