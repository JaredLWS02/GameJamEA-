using UnityEngine;

public class Level4EventTrigger : MonoBehaviour
{
    public WinningEvent eventManager;
    public bool isplayerInside;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.CompareTag("Player"))
            eventManager.PlayerEnter();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            eventManager.PlayerExit();
    }
}
