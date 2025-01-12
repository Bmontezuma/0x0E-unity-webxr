using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [Header("Physics Settings")]
    public float throwForce = 30f;   // Force applied when throwing the ball

    private Rigidbody rb;
    private bool isGrabbed = false;  // Whether the ball is grabbed

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.interpolation = RigidbodyInterpolation.Interpolate; // Smooth physics
    }

    void Update()
    {
        if (isGrabbed)
        {
            FollowGrabber();
        }
    }

    private void FollowGrabber()
    {
        // Follow the grabber (e.g., player hand or mouse position)
        Transform grabber = transform.parent;
        if (grabber != null)
        {
            rb.isKinematic = true; // Disable physics while grabbed
            transform.position = grabber.position;
        }
    }

    public void Grab(Transform grabber)
    {
        // Attach the ball to the grabber (e.g., player's hand)
        isGrabbed = true;
        transform.SetParent(grabber);
        rb.isKinematic = true; // Disable physics while grabbed
    }

    public void Release(Vector3 throwDirection)
    {
        // Detach the ball and apply throw force
        isGrabbed = false;
        transform.SetParent(null);
        rb.isKinematic = false; // Enable physics
        rb.AddForce(throwDirection * throwForce, ForceMode.Impulse); // Apply throw force
    }
}
