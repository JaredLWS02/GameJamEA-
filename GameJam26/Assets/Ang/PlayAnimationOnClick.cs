using UnityEngine;
using UnityEngine.UI;

public class PlayAnimationOnClick : MonoBehaviour
{
    public GameObject targetObject;
    public Animator animator;
    public UnityEngine.UI.Button playButton;
    public ActivateButtonAfterMusic activateButtonAfterMusic;

    void Start()
    {
        targetObject.SetActive(false);
    }

    public void PlayAnim()
    {
        if (playButton != null)
            playButton.interactable = false; // ✅ FIX

        targetObject.SetActive(true);

        animator.Rebind();
        animator.Update(0f);
        animator.SetBool("IsPlaying", true);

        if (AudioManager.instance.eventSFX3 != null)
        {
            AudioManager.instance.PlayEventSFX(AudioManager.instance.eventSFX3);
            AudioManager.instance.PauseBGM(AudioManager.instance.level5BGM);

            activateButtonAfterMusic.WaitForEvent(
                AudioManager.instance.eventSFX3
            );
        }
    }

}
