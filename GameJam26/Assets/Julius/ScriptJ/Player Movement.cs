using UnityEngine;
using UnityEngine.UIElements;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 8f;
    public float jumpForce = 14f;
    public Transform groundCheck;
    public float groundCheckDistance = 0.2f;
    public LayerMask jumpableLayer;
    private Animator animator;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool isFacingRight = true;
    private AudioManager audioManager;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("audioManager").GetComponent<AudioManager>();
    }
        void Update()
        {
            float moveInput = Input.GetAxisRaw("Horizontal");
            rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

            Flip(moveInput);

            RaycastHit2D hit = Physics2D.Raycast(
                groundCheck.position,
                Vector2.down,
                groundCheckDistance,
                jumpableLayer
            );

            isGrounded = hit.collider != null;

            animator.SetFloat("Speed", Mathf.Abs(moveInput));
            animator.SetBool("isGrounded", isGrounded);


            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                audioManager.PlayPlayerSFX(audioManager.jumpSFX);
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }
        }

        void Flip(float moveInput)
        {
            if (moveInput > 0 && !isFacingRight)
            {
                isFacingRight = true;
                Vector3 scale = transform.localScale;
                scale.x = Mathf.Abs(scale.x);
                transform.localScale = scale;
            }
            else if (moveInput < 0 && isFacingRight)
            {
                isFacingRight = false;
                Vector3 scale = transform.localScale;
                scale.x = -Mathf.Abs(scale.x);
                transform.localScale = scale;
            }
        }

        void OnDrawGizmos()
        {
            if (groundCheck != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(
                    groundCheck.position,
                    groundCheck.position + Vector3.down * groundCheckDistance
                );
            }
        }
    }

