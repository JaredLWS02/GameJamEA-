using UnityEngine;

public class PlayAnimationOnClick : MonoBehaviour
{
    public GameObject targetObject;
    public Animator animator;

    void Start()
    {
        targetObject.SetActive(false);
    }

    public void PlayAnim()
    {
        targetObject.SetActive(true);

        // force animator to restart cleanly
        animator.Rebind();
        animator.Update(0f);

        animator.SetBool("IsPlaying", true);
    }
}
