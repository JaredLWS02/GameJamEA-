using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed = 3f;
    public GameObject defeatUI;

    public Transform player;
    private Rigidbody2D rb;
    private bool stopMoving = false;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if (playerObj == null)
        {
            Debug.LogError("Player not found. Check Player tag.");
            return;
        }

        player = playerObj.transform;
        rb = GetComponent<Rigidbody2D>();

        if (defeatUI != null)
            defeatUI.SetActive(false);
    }

    void Update()
    {
        if (player == null || stopMoving)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HandlePlayerHit(collision.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Sparta"))
        {
            StopEnemy();
        }

        if (other.CompareTag("Player"))
        {
            HandlePlayerHit(other.gameObject);
        }
    }

    void HandlePlayerHit(GameObject playerObj)
    {
        PlayerMovement move = playerObj.GetComponent<PlayerMovement>();
        if (move != null)
            move.enabled = false;

        stopMoving = true;
        rb.linearVelocity = Vector2.zero;

        if (defeatUI != null)
            defeatUI.SetActive(true);
    }

    void StopEnemy()
    {
        stopMoving = true;
        rb.linearVelocity = Vector2.zero;
    }

}
