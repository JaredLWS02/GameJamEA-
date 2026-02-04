using UnityEngine;

public class WinningEvent : MonoBehaviour
{
    [Header("Settings")]
    public string playerTag = "Player";
    public string enemyTag = "Enemy";

    [Header("Event Triggers")]
    public Collider2D eventPointCollider; // Child collider for player
    public Collider2D spartaCollider;     // Child collider for enemy

    private bool playerInside = false;
    private bool enemyInside = false;
    private bool eventTriggered = false; // Only trigger once

    void Update()
    {
        // Check if both are inside
        if (playerInside && enemyInside && !eventTriggered)
        {
            TriggerSpartaEvent();
        }
    }

    private void TriggerSpartaEvent()
    {
        eventTriggered = true;

        // Disable player movement
        GameObject playerObj = GameObject.FindGameObjectWithTag(playerTag);
        if (playerObj != null)
        {
            var moveScript = playerObj.GetComponent<PlayerMovement>();
            if (moveScript != null)
                moveScript.enabled = false;
         
        }

        Debug.Log("Play this is Sparta animation");
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
