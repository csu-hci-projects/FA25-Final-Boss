using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = -9.81f;

    public Transform cameraTransform;
    private CharacterController controller;

    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        if (cameraTransform == null && Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    void Update()
    {
        float X = Input.GetAxisRaw("Horizontal");
        float Z = Input.GetAxisRaw("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = (forward * Z + right * X).normalized;

        // Apply movement
        controller.Move(moveDirection * speed * Time.deltaTime);

        // Apply gravity manually
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // small push downward to keep grounded
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
