using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;  // where the player will appear
    public string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            CharacterController cc = other.GetComponent<CharacterController>();

            // Disable CC temporarily to move player safely
            if (cc != null) cc.enabled = false;

            other.transform.position = teleportTarget.position;
            other.transform.rotation = teleportTarget.rotation;

            // Re-enable CC
            if (cc != null) cc.enabled = true;
        }
    }
}
