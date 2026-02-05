using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int hp = 1;
    public GameObject losepnael;

    void start()
    {
        losepnael.SetActive(false);
    }
    public void Hit()
    {
        hp--;

        if (hp <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        Time.timeScale = 0f; // Pause game
        losepnael.SetActive(true);
    }
}
