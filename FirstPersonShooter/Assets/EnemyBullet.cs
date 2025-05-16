using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float damage = 15f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth ph = collision.gameObject.GetComponent<PlayerHealth>();
            if (ph != null)
            {
                ph.TakeDamage(damage);
            }
        }

        Destroy(gameObject);
    }
}
