using UnityEngine;
using UnityEngine.AI;
using TMPro;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    [Header("Navigation")]
    public NavMeshAgent agent;
    public Transform[] waypoints;
    public Observer observer;
    public Transform player;

    [Header("Audio")]
    public AudioSource patrolAudio;
    public AudioSource chaseAudio;

    [Header("Footsteps Caption")]
    public TextMeshProUGUI footstepsCaption;
    public float hearingDistance = 14f;

    [Header("Speeds")]
    public float patrolSpeed = 2f;
    public float chaseSpeed = 4f;

    [Header("Event Voicelines")]
    public VoicelineClip spawnVoiceline;          // play when boss spawns
    public VoicelineClip caughtPlayerVoiceline;   // play when player is caught
    public VoicelineClip playerEscapeVoiceline;   // play when player escapes

    [Header("Optional Patrol Voicelines")]
    public VoicelineClip[] patrolVoicelines;      // random lines while patrolling
    public float patrolVoicelineInterval = 10f;

    private int waypointIndex = 0;
    private bool playerCaught = false;

    void Start()
    {
        agent.speed = patrolSpeed;
        GoToNextWaypoint();

        if (patrolAudio != null && !patrolAudio.isPlaying)
            patrolAudio.Play();

        if (footstepsCaption != null)
            footstepsCaption.gameObject.SetActive(false);

        // Play spawn voiceline once
        if (spawnVoiceline != null)
            Voicelines.instance.Say(spawnVoiceline);

        // Start patrol voiceline coroutine
        StartCoroutine(PatrolVoicelineRoutine());
    }

    void Update()
    {
        // ===== AI movement & chasing =====
        if (observer.IsPlayerInSight && !playerCaught)
        {
            playerCaught = true;
            agent.speed = chaseSpeed;
            agent.SetDestination(player.position);

            if (patrolAudio != null && patrolAudio.isPlaying)
                patrolAudio.Stop();

            if (chaseAudio != null && !chaseAudio.isPlaying)
                chaseAudio.Play();

            if (caughtPlayerVoiceline != null)
                Voicelines.instance.Say(caughtPlayerVoiceline);
        }
        else if (!observer.IsPlayerInSight)
        {
            agent.speed = patrolSpeed;

            if (chaseAudio != null && chaseAudio.isPlaying)
                chaseAudio.Stop();

            if (patrolAudio != null && !patrolAudio.isPlaying)
                patrolAudio.Play();

            if (!agent.pathPending && agent.remainingDistance < 0.2f)
                GoToNextWaypoint();

            // Reset caught state to allow chasing again
            playerCaught = false;
        }

        // ===== Footsteps caption =====
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

    IEnumerator PatrolVoicelineRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(patrolVoicelineInterval);

            if (!observer.IsPlayerInSight && patrolVoicelines.Length > 0)
            {
                int index = Random.Range(0, patrolVoicelines.Length);
                Voicelines.instance.Say(patrolVoicelines[index]);
            }
        }
    }

    // ===== Public method for escape events =====
    public void PlayerEscaped()
    {
        if (playerEscapeVoiceline != null)
            Voicelines.instance.Say(playerEscapeVoiceline);
    }
}
