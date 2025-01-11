using UnityEngine;

public class PinManager : MonoBehaviour
{
    public static PinManager Instance; // Singleton instance
    public int score = 0;              // Player's score

    private void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Score: " + score);
    }
}
