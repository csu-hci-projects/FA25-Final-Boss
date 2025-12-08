using UnityEngine;

public class KeyPickup : MonoBehaviour
{
    public float pickupDistance = 3f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        float dist = Vector3.Distance(player.position, transform.position);

        if (dist <= pickupDistance && Input.GetKeyDown(KeyCode.E))
        {
            PlayerInventory.hasKey = true;
            UIKeyDisplay.instance.ShowKeyIcon(true);
            Destroy(gameObject);
        }
    }
}
