using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [Header("References")]
    public Transform playerTarget;       // Drag the Player here in Inspector
    public Transform firePoint;          // An empty GameObject on enemy (e.g. mouth or hand)

    [Header("Bullet Settings")]
    public float bulletSpeed = 10f;
    public float fireRate = 1f;          // bullets per second
    public float bulletLifetime = 5f;
    public float bulletSize = 0.3f;      // sphere radius

    private float nextFireTime;

    void Update()
    {
        if (playerTarget == null || firePoint == null) return;

        if (Time.time >= nextFireTime)
        {
            ShootAtPlayer();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void ShootAtPlayer()
    {
        // Create sphere bullet
        GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        bullet.transform.position = firePoint.position;
        bullet.transform.localScale = Vector3.one * bulletSize;

        // Add physics
        Rigidbody rb = bullet.AddComponent<Rigidbody>();
        rb.useGravity = false;

        // Launch toward player
        Vector3 direction = (playerTarget.position - firePoint.position).normalized;
        rb.velocity = direction * bulletSpeed;

        // Optional: color the bullet
        Renderer renderer = bullet.GetComponent<Renderer>();
        if (renderer != null)
            renderer.material.color = Color.red;

        // Destroy bullet after a few seconds
        Destroy(bullet, bulletLifetime);
    }
}
