using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public float interactDistance = 3f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        float dist = Vector3.Distance(player.position, transform.position);

        if (dist <= interactDistance && Input.GetKeyDown(KeyCode.E))
        {
            if (Inventory.hasKey)
            {
                // Open the door
                Destroy(gameObject);
                Inventory.hasKey = false;
                KeyUI.instance.ShowKeyIcon(false);

                // Notify the enemy that the player escaped
                EnemyAI enemy = FindObjectOfType<EnemyAI>();
                if (enemy != null)
                    enemy.PlayerEscaped();  // Play escape voiceline
            }
            else
            {
                Debug.Log("Door is locked.");
            }
        }
    }
}
