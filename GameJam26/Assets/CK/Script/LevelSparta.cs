using UnityEngine;

public class LevelSparta : MonoBehaviour
{
    public WinningEvent eventManager;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Enemy"))
            eventManager.EnemyEnter();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
  
        if (other.CompareTag("Enemy"))
            eventManager.EnemyExit();
    }
}
