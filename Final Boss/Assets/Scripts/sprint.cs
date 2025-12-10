using UnityEngine;

[RequireComponent(typeof(Move))]
public class Sprint : MonoBehaviour
{
    [Header("Sprint Settings")]
    public float normalSpeed = 5f;
    public float sprintSpeed = 9f;
    public float acceleration = 10f;

    private Move movement;
    private float currentSpeed;
    private bool isSprinting;
    private bool canSprint = true;

    void Start()
    {
        movement = GetComponent<Move>();
        currentSpeed = normalSpeed;
    }

    void Update()
    {
        if(canSprint && Input.GetKey(KeyCode.LeftShift))
        {
            isSprinting = true;
        }
        else
        {
            isSprinting = false;
        }

        float targetSpeed;

        if (isSprinting)
        {
            Debug.Log("Player is sprinting → using sprintSpeed");
            targetSpeed = sprintSpeed;
        }
        else
        {
            Debug.Log("Player is walking → using normalSpeed");
            targetSpeed = normalSpeed;
        }

        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, Time.deltaTime * acceleration);
        movement.speed = currentSpeed;
    }
    public void SetSprintAllowed(bool allowed)
    {
        canSprint = allowed;
    }
    public bool CanSprint()
    {
        return canSprint;
    }
}
