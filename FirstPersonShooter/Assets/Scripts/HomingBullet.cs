using UnityEngine;

public class HomingBullet : MonoBehaviour
{
    [Header("References")]
    public Transform playerTarget;       // Drag Player here
    public Transform enemySource;        // Drag Enemy here (bullet spawns behind it)

    [Header("Settings")]
    public float speed = 10f;
    public float rotateSpeed = 200f;
    public float damage = 20f;
    public float spawnOffset = 1.5f;     // How far behind the enemy to spawn

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        if (enemySource != null)
        {
            // Move bullet to behind the enemy
            Vector3 behind = enemySource.position - enemySource.forward * spawnOffset;
            transform.position = behind;
        }

        if (playerTarget == null)
        {
            Debug.LogWarning("No player target assigned!");
        }
    }

    void FixedUpdate()
    {
        if (playerTarget == null) return;

        Vector3 direction = (playerTarget.position - transform.position).normalized;
        Vector3 rotateAmount = Vector3.Cross(transform.forward, direction);

        rb.angularVelocity = rotateAmount * rotateSpeed * Mathf.Deg2Rad;
        rb.velocity = transform.forward * speed;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerHealth health = collision.collider.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
                Debug.Log("Player hit by homing bullet!");
            }
        }

        Destroy(gameObject);
    }
}
