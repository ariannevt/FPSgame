using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    private NavMeshAgent agent;
    private int currentPoint = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GoToNextPoint();
    }

    void GoToNextPoint()
    {
        if (patrolPoints.Length == 0) return;
        agent.destination = patrolPoints[currentPoint].position;
        currentPoint = (currentPoint + 1) % patrolPoints.Length;
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            GoToNextPoint();
        }
    }

    private bool searching = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !searching)
        {
            StartCoroutine(Search());
        }
    }

    IEnumerator Search()
    {
        searching = true;
        float angle = 0f;

        while (angle < 360f)
        {
            transform.Rotate(0f, 30f * Time.deltaTime, 0f);
            angle += 30f * Time.deltaTime;
            yield return null;
        }

        searching = false;
    }

}
