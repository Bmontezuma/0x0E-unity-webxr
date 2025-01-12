using UnityEngine;

public class Pin : MonoBehaviour
{
    private bool hasFallen = false;

    void OnCollisionEnter(Collision collision)
    {
        if (!hasFallen && transform.up.y < 0.5f)
        {
            FindObjectOfType<ScoreManager>().IncrementScore();
            hasFallen = true;
        }
    }
}
