using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 10f;

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, 0.0f);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
