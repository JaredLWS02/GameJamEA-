using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Tooltip("Assign one or more falling prefabs. One will be chosen at random each spawn.")]
    public GameObject[] fallingPrefabs;
    public float spawnInterval = 1f;
    public float spawnXRange = 7f;
    public float spawnY = 6f;

    // Gizmo settings
    public Color gizmoColor = Color.cyan;
    public float gizmoHandleRadius = 0.15f;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 1f, spawnInterval);
    }

    void Spawn()
    {
        if (fallingPrefabs == null || fallingPrefabs.Length == 0)
            return;

        // Build a list of valid (non-null) prefabs so null entries are ignored
        List<GameObject> candidates = new List<GameObject>(fallingPrefabs.Length);
        foreach (var p in fallingPrefabs)
            if (p != null) candidates.Add(p);

        if (candidates.Count == 0)
            return;

        // Choose one at random
        GameObject chosen = candidates[Random.Range(0, candidates.Count)];

        float randomX = Random.Range(-spawnXRange, spawnXRange);
        Vector3 spawnPos = transform.position + new Vector3(randomX, spawnY, 0f);

        Instantiate(chosen, spawnPos, Quaternion.identity);
    }

    // Draw the spawn range in the Scene view when the object is selected
    void OnDrawGizmosSelected()
    {
        Gizmos.color = gizmoColor;
        Vector3 center = transform.position + new Vector3(0f, spawnY, 0f);
        Vector3 left = center + Vector3.left * spawnXRange;
        Vector3 right = center + Vector3.right * spawnXRange;

        // Line showing the horizontal spawn range
        Gizmos.DrawLine(left, right);

        // Handles at the boundaries
        Gizmos.DrawSphere(left, gizmoHandleRadius);
        Gizmos.DrawSphere(right, gizmoHandleRadius);
    }
}