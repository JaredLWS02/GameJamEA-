using UnityEngine;

public class ballEater : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("ball"))
        {
            Destroy(col.gameObject);
        }
    }
}
