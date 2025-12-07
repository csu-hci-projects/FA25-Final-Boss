using UnityEngine;

public class Observer : MonoBehaviour
{
    public Transform player;

    public bool IsPlayerInSight { get; private set; }
    private bool playerInsideTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideTrigger = true;
            CheckLineOfSight();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInsideTrigger = false;
            IsPlayerInSight = false;
        }
    }

    private void Update()
    {
        if (playerInsideTrigger)
            CheckLineOfSight();
    }

    void CheckLineOfSight()
    {
        Vector3 direction = player.position - transform.position;

        if (Physics.Raycast(transform.position, direction, out RaycastHit hit))
        {
            IsPlayerInSight = hit.collider.CompareTag("Player");
        }
        else
        {
            IsPlayerInSight = false;
        }
    }
}
