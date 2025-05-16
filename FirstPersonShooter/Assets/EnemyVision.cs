using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [Header("Vision Settings")]
    public Transform player;
    public float range = 15f;

    public bool playerInSight = false;

    void Update()
    {
        if (player == null) return;

        Vector3 direction = player.position - transform.position;
        float distance = direction.magnitude;

        if (distance <= range)
        {
            Ray ray = new Ray(transform.position, direction.normalized);
            if (Physics.Raycast(ray, out RaycastHit hit, range))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    playerInSight = true;
                    // Optional: Debug.Log("Player spotted");
                    return;
                }
            }
        }

        playerInSight = false;
    }
}
