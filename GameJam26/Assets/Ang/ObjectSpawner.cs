using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject fallingPrefab;
    public float spawnInterval = 1f;
    public float spawnXRange = 7f;
    public float spawnY = 6f;

    void Start()
    {
        InvokeRepeating(nameof(Spawn), 1f, spawnInterval);
    }

    void Spawn()
    {
        float randomX = Random.Range(-spawnXRange, spawnXRange);
        Vector2 spawnPos = new Vector2(randomX, spawnY);

        Instantiate(fallingPrefab, spawnPos, Quaternion.identity);
    }
}
