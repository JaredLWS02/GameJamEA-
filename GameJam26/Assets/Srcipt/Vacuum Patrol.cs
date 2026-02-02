

using UnityEngine;

public class VacuumPatrol : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 2f;
    private int direction = 1; // 1 = right, -1 = left
    
    void FixedUpdate()
    {
        transform.position += new Vector3(direction * moveSpeed * Time.deltaTime, 0, 0);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if we hit an obstacle to turn around
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            direction *= -1; // Reverse movement
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = this.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = null;
        }
    }

   
}
