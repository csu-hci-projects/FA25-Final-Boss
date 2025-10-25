using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5f;
    public Transform cameraTransform;
    private CharacterController controller;
    GameEnding gameEnding;

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            gameEnding.CaughtPlayer();
        }
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
        if(cameraTransform == null && Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
        }
            
    }

    void Update()
    {

        float X = Input.GetAxis("Horizontal"); 
        float Z = Input.GetAxis("Vertical");  

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = (forward * Z + right * X).normalized;

        controller.SimpleMove(moveDirection * speed);
    }
}
