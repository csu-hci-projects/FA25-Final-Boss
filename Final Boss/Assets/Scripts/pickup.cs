using UnityEngine;

public class Pickup : MonoBehaviour
{
    public float pickupDistance = 2f;
    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        float dist = Vector3.Distance(player.position, transform.position);

        if(dist <= pickupDistance && Input.GetKeyDown(KeyCode.E))
        {
            KeyUI.instance.ShowKeyIcon(true);
            Inventory.hasKey = true;
            Destroy(gameObject);
        }
    }

}
