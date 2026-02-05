using UnityEngine;

public class PlayAnimationOnClick : MonoBehaviour
{
    public GameObject targetObject;
    public Animator animator;

    void Start()
    {
        targetObject.SetActive(false); // hide at start
    }

    public void PlayAnim()
    {
        targetObject.SetActive(true);
        animator.SetTrigger("PlayAnimation");
    }
}
