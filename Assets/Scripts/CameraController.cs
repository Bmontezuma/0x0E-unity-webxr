using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float zoomSpeed = 10f;
    public float minZoom = 2f;   // Minimum allowed zoom distance
    public float maxZoom = 20f;  // Maximum allowed zoom distance

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 newPosition = transform.position + transform.forward * zoomSpeed * Time.deltaTime;
            if (Vector3.Distance(Vector3.zero, newPosition) < maxZoom)
                transform.position = newPosition;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 newPosition = transform.position - transform.forward * zoomSpeed * Time.deltaTime;
            if (Vector3.Distance(Vector3.zero, newPosition) > minZoom)
                transform.position = newPosition;
        }
    }
}
