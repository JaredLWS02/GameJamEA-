using UnityEngine;
using System.Collections;

public class counter : MonoBehaviour
{
    [SerializeField] private Button lc;
    [SerializeField] private Button rc;
    private bool trig;
    [SerializeField] private SpriteRenderer sr;
    [SerializeField] private SpriteRenderer sr1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trig = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (trig && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(pushed());
            if (lc.count != 6 && rc.count != 7)
            {
                lc.count = 0;
                rc.count = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        trig = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        trig &= false;
    }

    private IEnumerator pushed()
    {
        sr.enabled = false;
        sr1.enabled = true;
        yield return new WaitForSeconds(0.2f);
        sr1.enabled = false;
        sr.enabled = true;
    }
}
