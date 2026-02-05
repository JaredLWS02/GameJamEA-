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

    [Header("One-shot sounds")]
    [Tooltip("Sound played when the object falls off-screen (counts as a dodge).")]
    public AudioClip dodgeClip;
    [Tooltip("Sound played when the object hits the player.")]
    public AudioClip hitClip;
    [Range(0f, 1f)]
    public float soundVolume = 1f;

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
            // Play dodge sound (one-shot) if assigned
            PlayOneShot(dodgeClip);

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

            // Play hit sound (one-shot) if assigned
            PlayOneShot(hitClip);

            // DON'T count as dodge if it hit the player
            if (ObjectPooler.Instance != null)
                ObjectPooler.Instance.ReturnToPool(gameObject);
            else
                Destroy(gameObject);
        }
    }

    // Helper that plays a one-shot sound at the object's position (safe if clip is null)
    void PlayOneShot(AudioClip clip)
    {
        if (clip == null) return;

        // Try to play at object's position; fallback to camera position if needed
        Vector3 pos = transform.position;
        // If there's no AudioListener near object (e.g., UI-only), playing at camera keeps it audible
        if (Camera.main == null)
            AudioSource.PlayClipAtPoint(clip, pos, soundVolume);
        else
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, soundVolume);
    }
}
