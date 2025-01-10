using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float boostMultiplier = 2f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Rigidbody ballRb = other.GetComponent<Rigidbody>();
            if (ballRb != null)
            {
                ballRb.linearVelocity *= boostMultiplier;
            }
        }
    }
}
