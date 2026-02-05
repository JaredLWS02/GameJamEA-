

using UnityEngine;

public class VacuumPatrol : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 20f;
    private int direction = 1; // 1 = right, -1 = left
    public LayerMask turnAroundLayer;
<<<<<<< HEAD

    void FixedUpdate()
    {
        transform.position += new Vector3(direction * moveSpeed * Time.deltaTime, 0, 0);

=======
    public int winCountdown = 5;
    private AudioManager audioManager;
    private SpriteRenderer spriteRenderer;
    private Level3PlayerMovement player;
    void FixedUpdate()
    {
        transform.position += new Vector3(direction * moveSpeed * Time.deltaTime, 0, 0);
        audioManager = GameObject.FindGameObjectWithTag("audioManager").GetComponent<AudioManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Level3PlayerMovement>();
>>>>>>> Julius
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
<<<<<<< HEAD

   public void SpeedRandomize()
=======
    IEnumerator AttachPlayer(int countdown)
    {
       
        yield return new WaitForSeconds(winCountdown);
        moveSpeed = 0;
        player.OIIA();
        audioManager.PlayWinBGM();
        Debug.Log("Player Wins!");
        
    }
    public void SpeedRandomize()
>>>>>>> Julius
    {
        moveSpeed = Random.Range(1f, 40f);
        if (moveSpeed <= 20f)
        {
            spriteRenderer.color = Color.green;
        }
        else
        {
            spriteRenderer.color= Color.white;
        }
    }
}
