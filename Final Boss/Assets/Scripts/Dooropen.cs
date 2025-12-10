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
            if(Inventory.hasKey)
            {
                Destroy(gameObject);
                Inventory.hasKey = false;
                KeyUI.instance.ShowKeyIcon(false);
            }
            else
            {
                Debug.Log("Door is locked.");
            }
        }
    }
}
