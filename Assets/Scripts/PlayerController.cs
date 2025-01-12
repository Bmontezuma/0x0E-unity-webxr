using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed = 3f;          // Walking speed
    public float mouseSensitivity = 2f;  // Mouse sensitivity
    public float joystickSensitivity = 2f; // Joystick sensitivity (VR)

    private Vector2 vrMoveInput;          // Joystick movement input (VR)
    private Vector2 vrLookInput;          // Joystick look input (VR)
    private bool isVR = false;            // Is VR mode active?

    void Start()
    {
        // Detect if VR is active
        isVR = UnityEngine.XR.XRSettings.isDeviceActive;
    }

    void Update()
    {
        if (isVR)
        {
            HandleVRControls();
        }
        else
        {
            HandleKeyboardAndMouseControls();
        }
    }

    private void HandleKeyboardAndMouseControls()
    {
        // Walking movement with WASD or Arrow Keys
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        transform.Translate(movement * walkSpeed * Time.deltaTime, Space.World);

        // Mouse-based camera rotation
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up, mouseX); // Horizontal rotation
        Camera.main.transform.Rotate(Vector3.right, -mouseY); // Vertical rotation
    }

    private void HandleVRControls()
    {
        // Joystick movement
        Vector3 movement = new Vector3(vrMoveInput.x, 0, vrMoveInput.y);
        transform.Translate(movement * walkSpeed * Time.deltaTime, Space.World);

        // Joystick-based camera rotation
        float lookHorizontal = vrLookInput.x * joystickSensitivity;
        float lookVertical = vrLookInput.y * joystickSensitivity;

        transform.Rotate(Vector3.up, lookHorizontal); // Horizontal rotation
        Camera.main.transform.Rotate(Vector3.right, -lookVertical); // Vertical rotation
    }

    public void OnMove(InputValue value)
    {
        // Handle VR joystick movement
        vrMoveInput = value.Get<Vector2>();
    }

    public void OnLook(InputValue value)
    {
        // Handle VR joystick look input
        vrLookInput = value.Get<Vector2>();
    }
}
