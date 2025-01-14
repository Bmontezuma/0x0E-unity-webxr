using UnityEngine;
public class BallMovement : MonoBehaviour
{
    private Rigidbody rb;
    private bool isHeld = false;

    [Header("Throw Settings")]
    public float releaseVelocityMultiplier = 20f;
    public float releaseAngularVelocityMultiplier = 6f;

    [Header("Physics Settings")]
    public float mass = 7.26f;           // Regulation bowling ball mass (in kg)
    public float linearDamping = 0.1f;   // Linear movement resistance
    public float angularDamping = 0.2f;  // Rotational resistance
    public float bounceBounciness = 0.3f;
    public float friction = 0.6f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody is missing on the ball!");
            return;
        }

        ConfigurePhysics();
    }

    private void ConfigurePhysics()
    {
        // Set basic properties
        rb.mass = mass;
        rb.linearDamping = linearDamping;
        rb.angularDamping = angularDamping;
        rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        
        // Create and assign physics material
        PhysicsMaterial physicsMaterial = new PhysicsMaterial("BowlingBallMaterial");
        physicsMaterial.dynamicFriction = friction;
        physicsMaterial.staticFriction = friction;
        physicsMaterial.bounciness = bounceBounciness;
        physicsMaterial.frictionCombine = PhysicsMaterialCombine.Average;
        physicsMaterial.bounceCombine = PhysicsMaterialCombine.Multiply;

        // Apply physics material to collider
        Collider ballCollider = GetComponent<Collider>();
        if (ballCollider != null)
        {
            ballCollider.sharedMaterial = physicsMaterial;
        }
    }

    public void Grab(Transform grabPoint)
    {
        isHeld = true;
        rb.isKinematic = true;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        transform.position = grabPoint.position;
        transform.rotation = grabPoint.rotation;
    }

    public void Release(Vector3 throwDirection)
    {
        if (!isHeld) return;

        isHeld = false;
        transform.SetParent(null);
        rb.isKinematic = false;

        // Calculate throw velocity with consideration for gravity
        Vector3 throwVelocity = throwDirection.normalized * releaseVelocityMultiplier;
        
        // Add a slight upward component to counter immediate gravity drop
        throwVelocity += Vector3.up * 2f;
        
        // Apply velocities
        rb.linearVelocity = throwVelocity;
        
        // Calculate spin based on throw direction
        Vector3 spinAxis = Vector3.Cross(throwDirection, Vector3.up).normalized;
        rb.angularVelocity = spinAxis * releaseAngularVelocityMultiplier;

        // Ensure gravity is properly set
        Physics.gravity = new Vector3(0, -9.81f, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Apply additional friction when hitting the ground/lane
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Lane"))
        {
            // Reduce bounce on lane contact
            rb.linearVelocity = new Vector3(
                rb.linearVelocity.x, 
                rb.linearVelocity.y * 0.3f, 
                rb.linearVelocity.z
            );
            
            // Maintain forward momentum while adding natural roll
            Vector3 forwardDirection = new Vector3(
                rb.linearVelocity.x, 
                0, 
                rb.linearVelocity.z
            ).normalized;
            
            // Apply rolling motion
            rb.angularVelocity = new Vector3(
                -forwardDirection.z, 
                0, 
                forwardDirection.x
            ) * (rb.linearVelocity.magnitude * 0.5f);
        }
    }
}