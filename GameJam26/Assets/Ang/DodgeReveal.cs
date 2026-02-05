using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Tracks how many falling objects the player dodged and reveals an image
/// gradually as dodge count increases.
/// Example: set dodgesPerPercent = 10 to make 10 dodges == 1% reveal (1000 for full).
/// Also supports a simple win behavior: stop the game and activate a panel (assignable in inspector).
/// Added: assignable BGM and optional on-screen progress (Slider + Text).
/// </summary>
public class DodgeReveal : MonoBehaviour
{
    public static DodgeReveal Instance { get; private set; }


    [Tooltip("Number of dodged objects required to increase the reveal by 1%.")]
    public int dodgesPerPercent = 10; // 10 dodges -> 1%

    [Header("Win")]
    [Tooltip("Panel to activate when reveal reaches 100% (assign in inspector).")]
    public GameObject winPanel;
    [Tooltip("If true, Time.timeScale will be set to 0 when player wins.")]
    public bool pauseOnWin = true;

    [Header("On-screen progress (optional)")]
 
    public Slider revealSlider;

    int dodgeCount;
    bool hasWon;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else { Destroy(gameObject); return; }


        if (winPanel != null)
            winPanel.SetActive(false);

        // initialize optional UI
        if (revealSlider != null)
        {
            revealSlider.minValue = 0f;
            revealSlider.maxValue = 1f;
            revealSlider.value = 0f;
        }
    }

    /// <summary>
    /// Call to register a successful dodge (should be called only when object leaves screen).
    /// </summary>
    public void RegisterDodge(int amount = 1)
    {
        if (hasWon) return;

        dodgeCount += Mathf.Max(0, amount);

        float fullDodges = dodgesPerPercent * 100f;
        float progress01 = Mathf.Clamp01(dodgeCount / fullDodges);

        // update slider
        if (revealSlider != null)
            revealSlider.value = progress01;

        // win check
        if (progress01 >= 1f && !hasWon)
        {
            hasWon = true;
            HandleWin();
        }
    }


    /// <summary>
    /// Stops the game (optionally) and activates the assigned winPanel.
    /// Left minimal so you can modify or extend behavior.
    /// </summary>
    void HandleWin()
    {
        if (pauseOnWin)
            Time.timeScale = 0f;

        if (winPanel != null)
            winPanel.SetActive(true);
    }

    /// <summary>
    /// Utility: get current reveal percentage (0..100).
    /// </summary>
    public float GetRevealPercent()
    {
        float fullDodges = dodgesPerPercent * 100f;
        return Mathf.Clamp01(dodgeCount / fullDodges) * 100f;
    }

    /// <summary>
    /// Reset reveal progress and undo win state (restores Time.timeScale).
    /// Call this when restarting the level.
    /// </summary>
    public void ResetReveal()
    {
        dodgeCount = 0;
        hasWon = false;

        if (revealSlider != null)
            revealSlider.value = 0f;

        if (winPanel != null)
            winPanel.SetActive(false);

        // restore time scale if it was paused by win
        if (Time.timeScale == 0f)
            Time.timeScale = 1f;
    }
}