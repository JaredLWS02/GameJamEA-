using UnityEngine;
using UnityEngine.SceneManagement;

public class doorScript : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private SpriteRenderer sr2;
    [SerializeField] private string sceneName;
    [SerializeField] private bool trig;
    [SerializeField] private AudioSource opn;
    [SerializeField] private AudioSource cls;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sr.enabled = true;
        trig = false;
    }

    // Update is called once per frame
    void Update()
    {
        if ( trig == true && Input.GetKeyDown(KeyCode.E))
        {
            trig = false;
            SceneManager.LoadScene(sceneName);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            trig = true;
            opn.Play();
            sr.enabled = false;
            sr2.enabled = true;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            trig = false;
            cls.Play();
            sr2.enabled = false;
            sr.enabled = true;
        }
    }
}
