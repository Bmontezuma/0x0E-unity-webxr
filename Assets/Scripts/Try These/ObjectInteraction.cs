using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectInteraction : MonoBehaviour
{
    private bool isGrabbed = false;
    private Transform originalParent;
    private Vector3 offset;

    void Update()
    {
        // VR Interaction
        if (isGrabbed)
        {
            // Move the object with the controller
            transform.position = Camera.main.transform.position + offset;
        }

        // Keyboard/Mouse Interaction
        if (Input.GetMouseButtonDown(0) && !isGrabbed)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    Grab();
                }
            }
        }

        if (Input.GetMouseButtonUp(0) && isGrabbed)
        {
            Release();
        }
    }

    public void Grab()
    {
        isGrabbed = true;
        originalParent = transform.parent;
        transform.SetParent(Camera.main.transform);
        offset = transform.position - Camera.main.transform.position;
    }

    public void Release()
    {
        isGrabbed = false;
        transform.SetParent(originalParent);
    }
}