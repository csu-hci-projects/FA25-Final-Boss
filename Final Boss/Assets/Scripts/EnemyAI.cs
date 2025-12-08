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
    public AudioSource patrolAudio; 
    public AudioSource chaseAudio; 

    private int waypointIndex = 0;

    void Start()
    {
        agent.speed = patrolSpeed;
        GoToNextWaypoint();

        if (patrolAudio != null && !patrolAudio.isPlaying)
            patrolAudio.Play();
    }

    void Update()
    {
        if (observer.IsPlayerInSight)
        {
            agent.speed = chaseSpeed;
            agent.SetDestination(player.position);

            if (patrolAudio != null && patrolAudio.isPlaying)
                patrolAudio.Stop();

            if (chaseAudio != null && !chaseAudio.isPlaying)
                chaseAudio.Play();
        }
        else
        {
            agent.speed = patrolSpeed;


            if (chaseAudio != null && chaseAudio.isPlaying)
                chaseAudio.Stop();

            if (patrolAudio != null && !patrolAudio.isPlaying)
                patrolAudio.Play();

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
