using UnityEngine;
using UnityEngine.UIElements;

public class WallTrigger : MonoBehaviour
{
    public Transform targetWall;
    private GameObject player;
    public float offsetX = 0.5f;
    private VacuumPatrol vacuumPatrol;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        vacuumPatrol = FindAnyObjectByType<VacuumPatrol>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.transform.position = new Vector2(targetWall.transform.position.x + offsetX, player.transform.position.y) ;
            vacuumPatrol.SpeedRandomize();
        }
    }
}
