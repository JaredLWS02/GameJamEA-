using UnityEngine;

public class lv1panel : MonoBehaviour
{
    [SerializeField] private GameObject panel;

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            panel.SetActive(true);
        }
    }
}
