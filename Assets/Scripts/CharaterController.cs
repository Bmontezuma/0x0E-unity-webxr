using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float movementSpeed = 5f;
    public float mouseSensitivity = 100f;
    public Transform playerCamera; // The camera attached to the player

    private Rigidbody rb;
    private float verticalRotation = 0f;

    [Header("Ball Interaction")]
    public Transform grabPoint; // Where the ball will be held
    private GameObject grabbedBall; // Currently grabbed ball

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (playerCamera == null)
        {
            Debug.LogError("Player Camera is not assigned!");
        }

        // Lock the cursor to the game window
        Cursor.lockState = CursorLockMode.Locked;

        // Ensure Rigidbody and Collider setup
        if (rb == null)
        {
            Debug.LogError("Rigidbody is missing from the player!");
        }

        Collider col = GetComponent<Collider>();
        if (col == null)
        {
            Debug.LogError("Collider is missing from the player!");
        }
        else if (col.isTrigger)
        {
            Debug.LogError("Collider on the player should not be set as a trigger!");
            col.isTrigger = false;
        }
    }

    void Update()
    {
        HandleMouseLook();
        HandleBallInteraction();
    }

    void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);

        playerCamera.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

    private void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal"); // A/D keys
        float moveZ = Input.GetAxis("Vertical");   // W/S keys

        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;
        rb.MovePosition(rb.position + moveDirection * movementSpeed * Time.fixedDeltaTime);
    }

    private void HandleBallInteraction()
    {
        // Grab the ball with left mouse click
        if (Input.GetMouseButtonDown(0) && grabbedBall == null)
        {
            Ray ray = new Ray(playerCamera.position, playerCamera.forward);
            if (Physics.Raycast(ray, out RaycastHit hit, 5f))
            {
                if (hit.collider.CompareTag("BowlingBall"))
                {
                    grabbedBall = hit.collider.gameObject;
                    grabbedBall.GetComponent<BallMovement>().Grab(grabPoint);
                }
            }
        }

        // Release the ball with left mouse button release
        if (Input.GetMouseButtonUp(0) && grabbedBall != null)
        {
            Vector3 throwDirection = playerCamera.forward;
            grabbedBall.GetComponent<BallMovement>().Release(throwDirection);
            grabbedBall = null;
        }
    }
}
