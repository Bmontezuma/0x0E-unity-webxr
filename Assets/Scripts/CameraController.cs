using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float zoomSpeed = 10f;

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow)) transform.position += transform.forward * zoomSpeed * Time.deltaTime;
        if (Input.GetKey(KeyCode.DownArrow)) transform.position -= transform.forward * zoomSpeed * Time.deltaTime;
    }
}
