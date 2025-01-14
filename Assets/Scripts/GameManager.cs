using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance
    public TMP_Text scoreTMP;
    private int score = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PinFallen(BowlingPin pin)
    {
        AddScore(1);
        Debug.Log($"{pin.gameObject.name} has fallen. Score updated.");
    }

    private void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreTMP != null)
        {
            scoreTMP.text = "Score: " + score;
        }
    }
}
