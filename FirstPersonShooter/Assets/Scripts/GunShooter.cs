using UnityEngine;

public class GunShooter : MonoBehaviour
{
    [Header("Bullet Hole Prefab")]
    public GameObject BULLETNEW; // Assign bullet hole prefab in Inspector

    [Header("Gun Audio")]
    public AudioSource GUN_SHOT; // Assign AudioSource component with shooting sound

    [Header("Raycast Settings")]
    public float range = 100f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (Camera.main == null)
        {
            Debug.LogWarning("Main camera not found.");
            return;
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range))
        {
            if (BULLETNEW != null)
            {
                GameObject hole = Instantiate(
                    BULLETNEW,
                    hit.point + hit.normal * 0.01f, // Slight offset to prevent z-fighting
                    Quaternion.LookRotation(hit.normal)
                );
                hole.transform.SetParent(hit.collider.transform);
            }
            else
            {
                Debug.LogWarning("BULLETNEW prefab is not assigned.");
            }

            if (GUN_SHOT != null)
            {
                GUN_SHOT.Play();
            }
            else
            {
                Debug.LogWarning("GUN_SHOT AudioSource is not assigned.");
            }
        }
    }
}
