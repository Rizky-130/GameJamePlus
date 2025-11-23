using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public float score;
    public float scoreRate = 10f;
    public int digitCount =5;

    public DifficultyManager diff;

    

    void Update()
    {
        float dynamicSpeed = diff.currentSpeed;
        score += scoreRate * dynamicSpeed *  Time.deltaTime;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = ((int)score).ToString("D"+digitCount);
    }
}
