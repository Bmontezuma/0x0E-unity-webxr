using UnityEngine;

public class BallPickup : MonoBehaviour
{
    [Header("Grab Settings")]
    public Transform grabPoint; // The point where the ball is held
    private GameObject grabbedBall; // The currently grabbed ball

    void Update()
    {
        HandleGrabAndRelease();
    }

    private void HandleGrabAndRelease()
    {
        // Grab the ball on Left Mouse Button
        if (Input.GetMouseButtonDown(0) && grabbedBall == null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                if (hit.collider.CompareTag("BowlingBall"))
                {
                    grabbedBall = hit.collider.gameObject;
                    BallMovement ballMovement = grabbedBall.GetComponent<BallMovement>();
                    if (ballMovement != null)
                    {
                        ballMovement.Grab(grabPoint);
                    }
                }
            }
        }

        // Release the ball on Left Mouse Button release
        if (Input.GetMouseButtonUp(0) && grabbedBall != null)
        {
            BallMovement ballMovement = grabbedBall.GetComponent<BallMovement>();
            if (ballMovement != null)
            {
                Vector3 throwDirection = grabPoint.forward;
                ballMovement.Release(throwDirection);
            }
            grabbedBall = null; // Clear the reference
        }
    }
}
