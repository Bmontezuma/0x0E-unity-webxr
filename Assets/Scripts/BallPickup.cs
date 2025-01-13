using UnityEngine;

public class BallPickup : MonoBehaviour
{
    [Header("Grab Settings")]
    public Transform grabPoint;          // The point where the ball is held
    private GameObject grabbedBall;      // The currently grabbed ball

    void Update()
    {
        HandleGrabAndRelease();
    }

    private void HandleGrabAndRelease()
    {
        // Grab the ball on Left Mouse Button
        if (Input.GetMouseButtonDown(0) && grabbedBall == null)
        {
            // Raycast to grab the ball
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                if (hit.collider.CompareTag("BowlingBall"))
                {
                    grabbedBall = hit.collider.gameObject;
                    grabbedBall.GetComponent<BallMovement>().Grab(grabPoint);
                }
            }
        }

        // Release the ball on Left Mouse Button release
        if (Input.GetMouseButtonUp(0) && grabbedBall != null)
        {
            // Calculate throw direction (forward from the player)
            Vector3 throwDirection = transform.forward;

            // Release the ball
            grabbedBall.GetComponent<BallMovement>().Release(throwDirection);
            grabbedBall = null; // Clear the reference
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // VR: Grab the ball when the controller collides with it
        if (other.CompareTag("BowlingBall") && grabbedBall == null)
        {
            grabbedBall = other.gameObject;
            grabbedBall.GetComponent<BallMovement>().Grab(grabPoint);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // VR: Release the ball when the controller exits the ball
        if (other.CompareTag("BowlingBall") && grabbedBall != null)
        {
            Vector3 throwDirection = transform.forward;
            grabbedBall.GetComponent<BallMovement>().Release(throwDirection);
            grabbedBall = null;
        }
    }
}
