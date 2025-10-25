using UnityEngine;

[RequireComponent(typeof(FirstPersonMovement))]
public class PlayerSprint : MonoBehaviour
{
    [Header("Sprint Settings")]
    public float normalSpeed = 5f;
    public float sprintSpeed = 9f;
    public float acceleration = 10f;

    private FirstPersonMovement movement;
    private float currentSpeed;
    private bool isSprinting;
    private bool canSprint = true;

    void Start()
    {
        movement = GetComponent<FirstPersonMovement>();
        currentSpeed = normalSpeed;
    }

    void Update()
    {
        // Only allow sprinting if stamina system permits
        if (canSprint && Input.GetKey(KeyCode.LeftShift))
            isSprinting = true;
        else
            isSprinting = false;

        float targetSpeed = isSprinting ? sprintSpeed : normalSpeed;
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, Time.deltaTime * acceleration);
        movement.speed = currentSpeed;
    }

    // --- Called by the stamina system ---
    public void SetSprintAllowed(bool allowed)
    {
        canSprint = allowed;
    }

    public bool CanSprint()
    {
        return canSprint;
    }
}
