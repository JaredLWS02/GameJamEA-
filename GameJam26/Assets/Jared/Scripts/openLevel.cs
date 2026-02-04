using UnityEngine;
using UnityEngine.SceneManagement;

public class openLevel : MonoBehaviour
{
    public GameObject Catpanel;
    public GameObject interactables;

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
        if (interactables != null && !Catpanel.activeSelf)
        {
            interactables.SetActive(true);
        }
        else
        {
            interactables.SetActive(false);
        }
            if (col.gameObject.tag == "Player" 
            && Input.GetKeyDown(KeyCode.E) 
            && !Catpanel.activeSelf )
            {
                if (Catpanel != null)
                {
                    Catpanel.SetActive(true);
                }
            }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && interactables != null)
        {
            interactables.SetActive(false);
        }
    }
}
