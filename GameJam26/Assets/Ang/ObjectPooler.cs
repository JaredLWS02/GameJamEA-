using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Simple, general-purpose object pool that supports multiple prefab types.
/// Instances get a small PooledObject marker so they can be returned to the correct pool.
/// </summary>
public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance { get; private set; }

    [Tooltip("Default number of instances to prewarm per prefab when first requested.")]
    public int defaultPoolSize = 8;

    // Pool keyed by original prefab
    readonly Dictionary<GameObject, Queue<GameObject>> pools = new Dictionary<GameObject, Queue<GameObject>>();

    // Root transform for pooled objects
    Transform poolRoot;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);

        poolRoot = new GameObject("ObjectPoolRoot").transform;
        poolRoot.SetParent(transform, false);
    }

    // Spawn (reuse) an object from the pool for the given prefab.
    public GameObject SpawnFromPool(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        if (prefab == null) return null;

        if (!pools.TryGetValue(prefab, out var queue))
        {
            // Create and warm-up a queue for this prefab
            queue = new Queue<GameObject>();
            pools[prefab] = queue;
            for (int i = 0; i < defaultPoolSize; i++)
            {
                var go = CreateNewInstance(prefab);
                go.SetActive(false);
                queue.Enqueue(go);
            }
        }

        GameObject instance;
        // If pool has available instance, reuse; otherwise create new
        if (queue.Count > 0)
        {
            instance = queue.Dequeue();
            if (instance == null)
            {
                // In case the object was destroyed externally
                instance = CreateNewInstance(prefab);
            }
        }
        else
        {
            instance = CreateNewInstance(prefab);
        }

        instance.transform.SetParent(null);
        instance.transform.position = position;
        instance.transform.rotation = rotation;
        instance.SetActive(true);

        return instance;
    }

    // Return an instance to its pool (deactivate and enqueue)
    public void ReturnToPool(GameObject instance)
    {
        if (instance == null) return;

        var marker = instance.GetComponent<PooledObject>();
        if (marker == null || marker.prefab == null)
        {
            // Unknown instance: just destroy as fallback
            Destroy(instance);
            return;
        }

        instance.SetActive(false);
        instance.transform.SetParent(poolRoot);
        pools[marker.prefab].Enqueue(instance);
    }

    GameObject CreateNewInstance(GameObject prefab)
    {
        var go = Instantiate(prefab);
        // Add marker to track original prefab (used on return)
        var marker = go.GetComponent<PooledObject>();
        if (marker == null) marker = go.AddComponent<PooledObject>();
        marker.prefab = prefab;
        go.name = prefab.name + "_p";
        return go;
    }

    public void restartgame()
    {
        SceneManager.LoadSceneAsync(2);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void home()
    {
        SceneManager.LoadSceneAsync(0);
    }
}


/// <summary>
/// Marker attached to pooled instances so pool knows their original prefab.
/// </summary>
public class PooledObject : MonoBehaviour
{
    [HideInInspector] public GameObject prefab;
}
