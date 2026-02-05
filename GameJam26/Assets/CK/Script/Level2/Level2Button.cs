using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Level2Button : MonoBehaviour
{
    [Header("Scene Settings")]
    public string CorrectlevelName;
    public string WronglevelName;
    public bool CorrentButton = false;

    [Header("UI")]
    public GameObject UI;

    [Header("Audio")]
    public AudioClip CorrectSound;
    public AudioClip WrongSound;
    public AudioSource ButtonSound;

    private bool playerInside = false;
    private bool isLoading = false; // prevent spam

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            UI.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            UI.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInside && !isLoading && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(PlaySoundAndLoad());
        }
    }

    IEnumerator PlaySoundAndLoad()
    {
        isLoading = true;

        if (CorrentButton)
        {
            ButtonSound.PlayOneShot(CorrectSound);
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene(CorrectlevelName);
        }
        else
        {
            ButtonSound.PlayOneShot(WrongSound);
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene(WronglevelName);
        }
    }
}
