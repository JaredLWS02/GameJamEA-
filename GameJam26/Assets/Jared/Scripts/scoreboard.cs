using UnityEngine;
using TMPro;

public class scoreboard : MonoBehaviour
{
    public TMP_Text left;
    public TMP_Text right;
    public Button lbt;
    public Button rbt;
    private int lastScore = -1;
    private int lastScore1 = -1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lastScore != lbt.count)
        {
            lastScore = lbt.count;
            left.text = "Left counter: " + lbt.count.ToString();
        }

        if(lastScore1 != rbt.count)
        {
            lastScore1 = rbt.count;
            right.text = "Right counter: " + rbt.count.ToString();
        }
    }
}
