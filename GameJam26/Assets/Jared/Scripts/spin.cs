using UnityEngine;

public class spin : MonoBehaviour
{
    public PauseMenu pan;
    public Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pan.spin)
        {
            anim.enabled = true;
        }
    }
}
