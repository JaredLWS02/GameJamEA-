using UnityEngine;
using UnityEngine.SceneManagement;

public class openLevel : MonoBehaviour
{
    public GameObject Catpanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player" )
        {

        }
    }
}
