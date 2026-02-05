using UnityEngine;
using System.Collections;

public class WinningEvent : MonoBehaviour
{
    [Header("Settings")]
    public string playerTag = "Player";
    public string enemyTag = "Enemy";

    [Header("Event Triggers")]
    public Collider2D eventPointCollider;
    public Collider2D spartaCollider;

    private bool playerInside = false;
    private bool enemyInside = false;
    public bool eventTriggered = false;

    public Animator enemyAnimator;
    public AudioSource audioSource;  // Assign the sound to play
    [Header("Player Animation")]
    public RuntimeAnimatorController playerKickController;

    private RuntimeAnimatorController originalPlayerController;

    void Update()
    {
        if (playerInside && enemyInside && !eventTriggered)
        {
            TriggerSpartaEvent();
        }
    }

    private void TriggerSpartaEvent()
    {
        eventTriggered = true;

        GameObject playerObj = GameObject.FindGameObjectWithTag(playerTag);
        if (playerObj != null)
        {
            var moveScript = playerObj.GetComponent<PlayerMovement>();
            if (moveScript != null)
                moveScript.enabled = false;

            var animator = playerObj.GetComponent<Animator>();
            if (animator != null)
                originalPlayerController = animator.runtimeAnimatorController;
        }

       
        if (audioSource != null)
            audioSource.Play();
        StartCoroutine(ThisisSpartaAfterDelay(1.2f));
        //  Delay before swapping animator controller
        StartCoroutine(ChangePlayerAnimatorAfterDelay(1.25f));

        Debug.Log("Play THIS IS SPARTA animation");
    }

    private IEnumerator ChangePlayerAnimatorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        GameObject playerObj = GameObject.FindGameObjectWithTag(playerTag);
        if (playerObj == null) yield break;

        Animator playerAnimator = playerObj.GetComponent<Animator>();
        if (playerAnimator != null && playerKickController != null)
        {
            playerAnimator.runtimeAnimatorController = playerKickController;
        }
    }

    private IEnumerator ThisisSpartaAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        enemyAnimator.SetBool("isSparta", true);
    }
    // These functions are called by the child colliders
    public void PlayerEnter()
    {
        playerInside = true;
        Debug.Log("player inside");
    }

    public void PlayerExit()
    {
        playerInside = false;
    }

    public void EnemyEnter()
    {
        enemyInside = true;
        Debug.Log("enemy inside");
    }

    public void EnemyExit()
    {
        enemyInside = false;
    }
}
