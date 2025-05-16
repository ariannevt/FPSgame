using UnityEngine;

public class SciFiAutoDoor : MonoBehaviour
{
    public Transform door;
    public Vector3 openOffset = new Vector3(0, 3f, 0);
    public float speed = 3f;

    private Vector3 closedPos;
    private Vector3 openPos;
    private bool isOpen = false;

    void Start()
    {
        closedPos = door.position;
        openPos = closedPos + openOffset;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            isOpen = true;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            isOpen = false;
    }

    void Update()
    {
        door.position = Vector3.Lerp(door.position, isOpen ? openPos : closedPos, Time.deltaTime * speed);
    }
}
