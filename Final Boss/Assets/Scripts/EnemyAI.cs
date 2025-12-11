using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform[] waypoints;
    public Observer observer;
    public Transform player;

    // ===== Footsteps Caption =====
    public TextMeshProUGUI footstepsCaption;
    public float hearingDistance = 14f;    

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

  
        if (footstepsCaption != null)
            footstepsCaption.gameObject.SetActive(false);
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
                GoToNextWaypoint();
        }

        // ===== Footsteps Caption =====
        if (footstepsCaption != null && player != null)
        {
            bool audioPlaying = 
                (patrolAudio != null && patrolAudio.isPlaying) || 
                (chaseAudio != null && chaseAudio.isPlaying);

            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            bool showCaption = audioPlaying && distanceToPlayer <= hearingDistance;

            footstepsCaption.gameObject.SetActive(showCaption);

            if (showCaption)
                footstepsCaption.text = "Footsteps"; 
        }
    }

    void GoToNextWaypoint()
    {
        if (waypoints.Length == 0) return;

        agent.SetDestination(waypoints[waypointIndex].position);
        waypointIndex = (waypointIndex + 1) % waypoints.Length;
    }
}
