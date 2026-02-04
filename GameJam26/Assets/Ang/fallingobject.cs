using UnityEngine;

public class fallingobject : MonoBehaviour
{
    [Header("Base speed (used if randomization disabled)")]
    public float fallSpeed = 5f;

    [Header("Random speed range")]
    [Tooltip("Minimum falling speed (inclusive).")]
    public float minFallSpeed = 3f;
    [Tooltip("Maximum falling speed (exclusive).")]
    public float maxFallSpeed = 7f;

    [Tooltip("If true, a random fallSpeed will be chosen each time the object is enabled.")]
    public bool randomizeOnEnable = true;

    void OnEnable()
    {
        if (randomizeOnEnable)
        {
            // Ensure range is valid
            if (minFallSpeed > maxFallSpeed)
            {
                float tmp = minFallSpeed;
                minFallSpeed = maxFallSpeed;
                maxFallSpeed = tmp;
            }

            fallSpeed = Random.Range(minFallSpeed, maxFallSpeed);
        }
    }

    void Update()
    {
        transform.Translate(Vector2.down * fallSpeed * Time.deltaTime);

        // Return to pool if off screen — counts as a successful dodge
        if (transform.position.y < -6f)
        {
            // Notify dodge tracker (only when object leaves the screen)
            DodgeReveal.Instance?.RegisterDodge(1);

            if (ObjectPooler.Instance != null)
                ObjectPooler.Instance.ReturnToPool(gameObject);
            else
                Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Notify player
            collision.GetComponent<PlayerHealth>()?.Hit();

            // DON'T count as dodge if it hit the player
            if (ObjectPooler.Instance != null)
                ObjectPooler.Instance.ReturnToPool(gameObject);
            else
                Destroy(gameObject);
        }
    }
}
