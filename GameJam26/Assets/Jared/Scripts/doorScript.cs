using UnityEngine;
using UnityEngine.SceneManagement;

public class doorScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private SpriteRenderer sr2;
    [SerializeField] private string sceneName;
    private bool trig;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr.enabled = true;
        trig = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ( trig = true && Input.GetKeyDown(KeyCode.E))
        {
                SceneManager.LoadScene(sceneName);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            trig = true;
            sr.enabled = false;
            sr2.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            trig = false;
            sr2.enabled = false;
            sr.enabled = true;
        }
    }
}
