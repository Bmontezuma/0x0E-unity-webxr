using UnityEngine;
using UnityEngine.XR; // Required for CommonUsages
using UnityEngine.XR.Management; // Required for XRGeneralSettings
using UnityEngine.InputSystem; // Required for InputActionProperty
using UnityEngine.XR.Interaction.Toolkit.Inputs; // Required for new Input System

public class DualInputHandler : MonoBehaviour
{
    public float moveSpeed = 10f; // Movement speed for keyboard and VR
    public Rigidbody ballRigidbody; // Rigidbody for throwing actions
    public float throwForce = 10f; // Force for throwing the ball

    // Pickup/Drop settings
    private GameObject heldObject = null; // Currently held object
    public Transform handTransform; // Transform to attach held objects

    // Input Action-based Controllers (New Input System)
    public InputActionProperty leftControllerMovement;
    public InputActionProperty rightControllerTrigger;
    public InputActionProperty leftControllerGrip;

    // Input variables
    private bool isUsingVR = false;

    void Start()
    {
        // Check if XR (VR) is active
        var xrSettings = XRGeneralSettings.Instance;
        isUsingVR = xrSettings != null && xrSettings.Manager.isInitializationComplete;
    }

    void Update()
    {
        if (isUsingVR)
        {
            HandleVRInput();
        }
        else
        {
            HandleKeyboardInput();
        }
    }

    void HandleKeyboardInput()
    {
        // Movement (WASD or Arrow Keys)
        float moveX = Input.GetAxis("Horizontal"); // Old Input System
        float moveZ = Input.GetAxis("Vertical");   // Old Input System
        Vector3 move = new Vector3(moveX, 0, moveZ) * moveSpeed * Time.deltaTime;
        transform.Translate(move, Space.Self);

        // Rotate (A/D or Arrow Keys Left/Right)
        if (Input.GetKey(KeyCode.A)) // Old Input System
        {
            transform.Rotate(0, -moveSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D)) // Old Input System
        {
            transform.Rotate(0, moveSpeed * Time.deltaTime, 0);
        }

        // Throw the ball with Spacebar
        if (Input.GetKeyDown(KeyCode.Space)) // Old Input System
        {
            ThrowBall();
        }

        // Pickup object with E
        if (Input.GetKeyDown(KeyCode.E)) // Old Input System
        {
            PickupObject();
        }

        // Drop object with Q
        if (Input.GetKeyDown(KeyCode.Q)) // Old Input System
        {
            DropObject();
        }
    }

    void HandleVRInput()
    {
        // Movement with left controller joystick (New Input System)
        Vector2 movementInput = leftControllerMovement.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y) * moveSpeed * Time.deltaTime;
        transform.Translate(move, Space.Self);

        // Throw the ball with right controller trigger (New Input System)
        if (rightControllerTrigger.action.ReadValue<float>() > 0.5f)
        {
            ThrowBall();
        }

        // Pickup object with left controller grip (New Input System)
        if (leftControllerGrip.action.ReadValue<float>() > 0.5f && heldObject == null)
        {
            PickupObject();
        }

        // Drop object with left controller grip release (New Input System)
        if (leftControllerGrip.action.ReadValue<float>() <= 0.5f && heldObject != null)
        {
            DropObject();
        }
    }

    void PickupObject()
    {
        if (heldObject == null)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
            {
                if (hit.collider.CompareTag("Pickup"))
                {
                    heldObject = hit.collider.gameObject;
                    heldObject.transform.SetParent(handTransform);
                    heldObject.transform.localPosition = Vector3.zero;
                    heldObject.GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }
    }

    void DropObject()
    {
        if (heldObject != null)
        {
            heldObject.GetComponent<Rigidbody>().isKinematic = false;
            heldObject.transform.SetParent(null);
            heldObject = null;
        }
    }

    void ThrowBall()
    {
        if (ballRigidbody != null)
        {
            ballRigidbody.AddForce(transform.forward * throwForce, ForceMode.Impulse);
        }
    }
}
