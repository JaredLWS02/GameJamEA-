using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

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
<<<<<<< Updated upstream
    private AudioManager audioManager;
    private BackgroundColor backgroundColor;
    public GameObject nextLevel;
   
=======

>>>>>>> Stashed changes
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
<<<<<<< Updated upstream
        audioManager = GameObject.FindGameObjectWithTag("audioManager").GetComponent<AudioManager>();
        backgroundColor = GameObject.FindAnyObjectByType<BackgroundColor>();
        nextLevel.gameObject.SetActive(false);
=======
>>>>>>> Stashed changes
    }
   void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
          rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

<<<<<<< Updated upstream
            Flip(moveInput);
=======
        Flip(moveInput);

        RaycastHit2D hit = Physics2D.Raycast(
            groundCheck.position,
            Vector2.down,
            groundCheckDistance,
            jumpableLayer
        );
>>>>>>> Stashed changes

            RaycastHit2D hit = Physics2D.Raycast(
                groundCheck.position,
                Vector2.down,
                groundCheckDistance,
                jumpableLayer
            );

<<<<<<< Updated upstream
            isGrounded = hit.collider != null;

            animator.SetFloat("Speed", Mathf.Abs(moveInput));
            animator.SetBool("isGrounded", isGrounded);


            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                audioManager.PlayPlayerSFX(audioManager.jumpSFX);
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }
=======
        animator.SetFloat("Speed", Mathf.Abs(moveInput));
        animator.SetBool("isGrounded", isGrounded);


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
>>>>>>> Stashed changes
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

    

    public void OIIA()
    {
        StartCoroutine(ScaleOverTime(new Vector3(30f, 30f, 30f), 1f));
    }
    IEnumerator ScaleOverTime(Vector3 targetScale, float duration)
    {
        Vector3 startScale = transform.localScale;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            transform.localScale = Vector3.Lerp(startScale, targetScale, t);
            yield return null;
        }

        transform.localScale = targetScale; // ensure exact final size
        animator.SetTrigger("OIIA");
        backgroundColor.StartRainbow();
        nextLevel.gameObject.SetActive(true);
        enabled = false;
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

