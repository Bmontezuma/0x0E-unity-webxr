using UnityEngine;

public class Pin : MonoBehaviour
{
    void Start()
    {
        // Initialization logic for the pin
        Debug.Log("Pin initialized.");
    }

    void Update()
    {
        // Optional: Pin behavior logic
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 1.0f) // Adjust magnitude threshold as needed
        {
            // Play collision sound, if required
            GetComponent<AudioSource>()?.Play();
        }
    }

    // Logic to check if the pin has fallen
    private bool IsFallen()
    {
        float tiltAngle = Vector3.Angle(Vector3.up, transform.up);
        return tiltAngle > 30f; // Tilt threshold for falling
    }
}
