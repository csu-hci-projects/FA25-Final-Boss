using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Crouch : MonoBehaviour
{
    [Header("Crouch Settings")]
    public float crouchHeight = 1.0f;     
    public float standHeight = 2.0f;      
    public float crouchSpeed = 5f;        
    public Transform cameraTransform;     

    private CharacterController controller;
    private float currentHeight;
    private bool isCrouching;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentHeight = standHeight;

        if(cameraTransform == null && Camera.main != null)
        {
            cameraTransform = Camera.main.transform;
        }      
    }

    void Update()
    {
        // Hold Left Ctrl to crouch
        if (Input.GetKey(KeyCode.LeftControl))
        {
            isCrouching = true;
        }
        else
        {
            isCrouching = false;
        }

        float targetHeight;

        if(isCrouching)
        {
            targetHeight = crouchHeight;
        }
        else
        {
            targetHeight = standHeight;
        }

        controller.height = targetHeight;

        Vector3 center = controller.center;
        center.y = controller.height / 2f;
        controller.center = center;

        Vector3 camPos = cameraTransform.localPosition;
        camPos.y = Mathf.Lerp(camPos.y, controller.height - 0.2f, Time.deltaTime * crouchSpeed);
        cameraTransform.localPosition = camPos;
    }
}
