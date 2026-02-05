using UnityEngine;

public class Button2_5ButtonManger : MonoBehaviour
{
    public float timeLimit = 3f;
    public Level2_5Button buttonA;
    public Level2_5Button buttonB;
    public Level2_5Door Door;

    public bool isBothPressed = false;
    public int pressedCount { get; private set; } = 0;

    private float timer;
    private bool timerRunning = false;

    public void ButtonPressed()
    {
        pressedCount++;
        Door.sr.enabled = false;
        Door.sr2.enabled = true;

        if (!timerRunning)
        {
            timerRunning = true;
            timer = timeLimit;
        }

        if (pressedCount >= 2)
        {
            isBothPressed = true;
            timerRunning = false;
            Debug.Log("Both buttons pressed in time!");
        }
    }

    void Update()
    {
        if (!timerRunning) return;

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            ResetButtons();
        }
    }

    void ResetButtons()
    {
        Debug.Log("Timer expired, reset buttons");

        pressedCount = 0;
        isBothPressed = false;
        timerRunning = false;

        buttonA.ResetButton();
        buttonB.ResetButton();
        Door.sr.enabled = true;
        Door.sr2.enabled = false;

    }
}
