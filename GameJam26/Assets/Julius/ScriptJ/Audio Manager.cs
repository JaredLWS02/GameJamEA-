using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    #region Declaration

    [Header("------------------- Audio Source ------------------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource playerSFXSource;
    [SerializeField] AudioSource gameSFXSource;
    [SerializeField] AudioSource eventSFXSource;
    [Header("-------------------BGM Audio Clips ------------------")]
    
    public AudioClip mainmenuBGM;
    public AudioClip level1BGM;
    public AudioClip level2BGM;
    public AudioClip level3BGM;
    public AudioClip level4BGM;
    public AudioClip level5BGM;
    public AudioClip winBGM;
    public AudioClip loseBGM;
    public AudioClip extraBGM1;
    public AudioClip extraBGM2;
    public AudioClip extraBGM3;
    [Header("----------------Player SFX Audio Clips ---------------")]
    public AudioClip jumpSFX;
    public AudioClip jumpSFX2;
    public AudioClip landSFX;
    public AudioClip landSFX2;
    public AudioClip pickupSFX;
    public AudioClip deathSFX;
    public AudioClip deathSFX2;
    [Header("----------------Game SFX Audio Clips ---------------")]
    public AudioClip vacuumSFX;
    public AudioClip gameSFX2;
    public AudioClip gameSFX3;
    public AudioClip gameSFX4;
    public AudioClip gameSFX5;
    public AudioClip gameSFX6;
    public AudioClip gameSFX7;
    public AudioClip gameSFX8;
    [Header("----------------Event SFX Audio Clips ---------------")]
    public AudioClip eventSFX;
    public AudioClip eventSFX2;
    public AudioClip eventSFX3;
    public AudioClip eventSFX4;
    public AudioClip eventSFX5;
    public AudioClip eventSFX6;
    public AudioClip eventSFX7;
    public AudioClip eventSFX8;
    public AudioClip eventSFX9;
    public AudioClip eventSFX10;
    public AudioClip eventSFX11;
    #endregion Declaration

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string activeSceneName = SceneManager.GetActiveScene().name;
        if (activeSceneName == "Level Selection")
        {
            Debug.Log("Got bgm clip");
            musicSource.clip = mainmenuBGM;
        }
        else if (activeSceneName =="Level 1")
        {
            musicSource.clip = level1BGM;
        }
        else if (activeSceneName == "Level 2")
        {
            musicSource.clip = level2BGM;
        }
        else if (activeSceneName == "Level 3")
        {
            musicSource.clip = level3BGM;
        }
        else if (activeSceneName == "Level 4")
        {
            musicSource.clip = level4BGM;
        }
        else if (activeSceneName == "Level 5")
        {
            musicSource.clip = level5BGM;
        }

        //Debug.Log("try to play.current scene ="+activeSceneName);
        musicSource.Play();
    }

    public void PlayWinBGM()
    {
        musicSource.clip = winBGM;
        musicSource.Play();
    }

    public void PlayLoseBGM()
    {
        musicSource.clip = loseBGM;
        musicSource.Play();
    }

    public void PlayPlayerSFX(AudioClip clip)
    {
        playerSFXSource.PlayOneShot(clip);
    }


    public void PlayGameSFX(AudioClip clip)
    {
        gameSFXSource.PlayOneShot(clip);
    }

    public void PlayEventSFX(AudioClip clip)
    {       
        eventSFXSource.PlayOneShot(clip);
    }

}
