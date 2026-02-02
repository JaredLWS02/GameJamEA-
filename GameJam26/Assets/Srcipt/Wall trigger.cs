using UnityEngine;

public class WallTrigger : MonoBehaviour
{
    private SceneFade sceneFade;

    private void Start()
    {
        // Find SceneFade anywhere in the scene
        sceneFade = FindFirstObjectByType<SceneFade>();

        if (sceneFade == null)
        {
            Debug.LogError("SceneFade not found in the scene!");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && sceneFade != null)
        {
            sceneFade.RestartScene();
        }
    }
}
