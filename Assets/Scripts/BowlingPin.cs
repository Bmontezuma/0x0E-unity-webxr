using UnityEngine;

public class BowlingPin : MonoBehaviour
{
    private bool hasFallen = false; // Tracks if the pin has already been counted
    public float fallThreshold = 30f; // Angle threshold to detect if the pin has fallen

    private AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check if the pin is knocked over
        if (!hasFallen && IsFallen())
        {
            hasFallen = true; // Prevent duplicate scoring
            PinManager.Instance.AddScore(1); // Add score through the PinManager
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Play the sound effect when the pin is hit
        if (audioSource != null && collision.relativeVelocity.magnitude > 1.0f) // Adjust magnitude threshold as needed
        {
            audioSource.Play();
        }
    }

    // Check if the pin's rotation indicates it has fallen
    private bool IsFallen()
    {
        float tiltAngle = Vector3.Angle(Vector3.up, transform.up);
        return tiltAngle > fallThreshold;
    }
}
