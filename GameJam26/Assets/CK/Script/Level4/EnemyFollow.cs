using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed = 3f;
    public DefeatUI defeatUI;

    public Transform player;
    private Rigidbody2D rb;
    private bool stopMoving = false;

    [Header("Audio")]
    public AudioSource runAudio;
    public float playInterval = 4f;
    private float soundTimer = 0f;
    private bool hasPlayedRunSound = false;


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
    }

    void Update()
    {
        if (player == null || stopMoving)
        {
            rb.linearVelocity = Vector2.zero;
            StopRunSound();
            return;
        }

        // Enemy moving
        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;

        HandleRunSound();
    }

    void HandleRunSound()
    {
        if (!hasPlayedRunSound)
        {
            runAudio.Play();          // play immediately
            hasPlayedRunSound = true;
            soundTimer = 0f;
            return;
        }

        soundTimer += Time.deltaTime;

        if (soundTimer >= playInterval)
        {
            runAudio.Play();
            soundTimer = 0f;
        }
    }

    void StopRunSound()
    {
        soundTimer = 0f;
        hasPlayedRunSound = false;

        if (runAudio.isPlaying)
            runAudio.Stop();
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
        StopRunSound();

        defeatUI.isDefeat();
    }

    void StopEnemy()
    {
        stopMoving = true;
        rb.linearVelocity = Vector2.zero;
        StopRunSound();
    }
}
