using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform[] waypoints;
    public Observer observer;
    public Transform player;

    public float patrolSpeed = 2f;
    public float chaseSpeed = 4f;

    private int waypointIndex = 0;

    void Start()
    {
        agent.speed = patrolSpeed;
        GoToNextWaypoint();
    }

    void Update()
    {
        if (observer.IsPlayerInSight)
        {
            agent.speed = chaseSpeed;
            agent.SetDestination(player.position);
        }
        else
        {
            agent.speed = patrolSpeed;

            if (!agent.pathPending && agent.remainingDistance < 0.2f)
            {
                GoToNextWaypoint();
            }
        }
    }

    void GoToNextWaypoint()
    {
        if (waypoints.Length == 0) return;

        agent.SetDestination(waypoints[waypointIndex].position);
        waypointIndex = (waypointIndex + 1) % waypoints.Length;
    }
}
