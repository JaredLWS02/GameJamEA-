using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerMovement5 : MonoBehaviour
{
    public float moveSpeed = 5f;

    Animator animator;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // default facing right
        spriteRenderer.flipX = false;
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");

        // move player
        transform.Translate(Vector2.right * moveX * moveSpeed * Time.deltaTime);

        // animation
        animator.SetBool("IsWalking", moveX != 0);

        // flip sprite
        if (moveX > 0)
            spriteRenderer.flipX = false; // right
        else if (moveX < 0)
            spriteRenderer.flipX = true;  // left
    }
}
