

using UnityEngine;

public class VacuumPatrol : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 20f;
    private int direction = 1; // 1 = right, -1 = left
    public LayerMask turnAroundLayer;

    void FixedUpdate()
    {
        transform.position += new Vector3(direction * moveSpeed * Time.deltaTime, 0, 0);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      
        if (((1 << collision.gameObject.layer) & turnAroundLayer) != 0)
        {
            direction *= -1;
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

   public void SpeedRandomize()
    {
        moveSpeed = Random.Range(1f, 40f);
    }
}
