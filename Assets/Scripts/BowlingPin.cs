using UnityEngine;

public class BowlingPin : MonoBehaviour
{
    private bool hasFallen = false;
    public float fallThreshold = 15f; // Lowered for better tilt detection

    void Update()
    {
        if (!hasFallen && IsFallen())
        {
            hasFallen = true;
            GameManager.Instance.PinFallen(this);
        }
    }

    private bool IsFallen()
    {
        float tiltAngle = Vector3.Angle(Vector3.up, transform.up);
        return tiltAngle > fallThreshold;
    }
}
