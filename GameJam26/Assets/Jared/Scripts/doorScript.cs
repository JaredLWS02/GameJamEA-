using UnityEngine;

public class doorScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private SpriteRenderer sr2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            sr.enabled = false;
            sr2.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            sr2.enabled = false;
            sr.enabled = true;
        }
    }
}
