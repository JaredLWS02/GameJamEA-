using UnityEngine;
using UnityEngine.UI;

public class PlayAnimationOnClick : MonoBehaviour
{
    public GameObject targetObject;
    public Animator animator;
    public UnityEngine.UI.Button playButton;
    public ActivateButtonAfterMusic activateButtonAfterMusic;
    private AudioManager audioManager;

    void Start()
    {
        targetObject.SetActive(false);
        audioManager = GameObject.FindGameObjectWithTag("audioManager").GetComponent<AudioManager>();
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
            audioManager.ChangeBGM("Level 2");
            audioManager.PauseBGM(audioManager.level5BGM);
           activateButtonAfterMusic.WaitForEvent();

            
        }
    }

}
