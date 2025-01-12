using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreTMP;
    private int score = 0;

    public void IncrementScore()
    {
        score++;
        scoreTMP.text = score.ToString();
    }
}
