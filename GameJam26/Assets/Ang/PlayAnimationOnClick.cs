using UnityEngine;
using UnityEngine.UI;

public class PlayAnimationOnClick : MonoBehaviour
{
    public GameObject targetObject;
    public Animator animator;
    public UnityEngine.UI.Button playButton;

    void Start()
    {
        targetObject.SetActive(false);
    }

    public void PlayAnim()
    {
        // Disable the button so it can't be clicked again
        if (playButton != null)
            playButton.enabled = false;

        targetObject.SetActive(true);

        animator.Rebind();
        animator.Update(0f);
        animator.SetBool("IsPlaying", true);

        // Check if AudioManager exists
        if (AudioManager.instance != null)
        {
            // If the currently playing clip is Level 5 BGM, use Pause()
            // We can't access musicSource directly, so let's check via the clip
            if (AudioManager.instance.level5BGM == AudioManager.instance.level5BGM) // <-- just placeholder, we will fix
            {
                // Since musicSource is private, we can just stop the BGM by calling PlayEventSFX instead
                // Or alternatively, we can add a public method in AudioManager to pause music
                AudioManager.instance.PauseBGM(AudioManager.instance.level5BGM);

            }

            // Play eventSFX3
            if (AudioManager.instance.eventSFX3 != null)
            {
                AudioManager.instance.PlayEventSFX(AudioManager.instance.eventSFX3);
            }
        }
    }
}
