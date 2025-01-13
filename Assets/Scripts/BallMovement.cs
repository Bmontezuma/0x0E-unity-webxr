using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [Header("Physics Settings")]
    public float throwForce = 3500f; // Base throw force

    private Rigidbody rb;
    private bool isGrabbed = false;

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
        Transform grabber = transform.parent;
        if (grabber != null)
        {
            rb.isKinematic = true; // Disable physics while grabbed
            transform.position = grabber.position;
        }
    }

    public void Grab(Transform grabber)
    {
        isGrabbed = true;
        transform.SetParent(grabber);
        rb.isKinematic = true; // Disable physics while grabbed
        rb.linearVelocity = Vector3.zero; // Reset velocity
        rb.angularVelocity = Vector3.zero; // Reset spin
    }

    public void Release(Vector3 throwDirection)
    {
        isGrabbed = false;
        transform.SetParent(null);
        rb.isKinematic = false; // Enable physics

        float scaledForce = throwForce / rb.mass; // Scale force by mass
        rb.linearVelocity = throwDirection.normalized * scaledForce; // Apply throw velocity

        Debug.Log($"Throw Direction: {throwDirection}, Scaled Force: {scaledForce}, Velocity: {rb.linearVelocity}");
    }
}
