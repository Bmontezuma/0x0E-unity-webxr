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
                // Apply minimum velocity boost
                if (ballRb.linearVelocity.magnitude < 1f)
                {
                    ballRb.linearVelocity = ballRb.linearVelocity.normalized * boostMultiplier;
                }
                else
                {
                    ballRb.linearVelocity *= boostMultiplier;
                }
                Debug.Log($"Ball boosted. New velocity: {ballRb.linearVelocity}");
            }
        }
    }
}
