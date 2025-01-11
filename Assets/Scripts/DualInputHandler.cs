using UnityEngine;
using UnityEngine.XR.Management; // Required for XRGeneralSettings
using UnityEngine.XR.Interaction.Toolkit;

public class DualInputHandler : MonoBehaviour
{
    public float moveSpeed = 5f;  // Movement speed for keyboard input
    public Rigidbody ballRigidbody; // Rigidbody for throwing actions
    public float throwForce = 10f;  // Force for throwing the ball

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
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(moveX, 0, moveZ) * moveSpeed * Time.deltaTime;
        transform.Translate(move);

        // Throw the ball with Spacebar
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowBall();
        }
    }

    void HandleVRInput()
    {
        // Add VR interaction logic here
        Debug.Log("Handling VR Input (implement as needed).");
    }

    void ThrowBall()
    {
        if (ballRigidbody != null)
        {
            ballRigidbody.AddForce(transform.forward * throwForce, ForceMode.Impulse);
        }
    }
}
