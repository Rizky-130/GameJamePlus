using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    public float score;               // untuk hitungan realtime
    public float scoreRate = 10f;
    public int digitCount = 5;

    public DifficultyManager diff;

    void Update()
    {
        float dynamicSpeed = diff.currentSpeed;
        score += scoreRate * dynamicSpeed * Time.deltaTime;
        UpdateScore();
    }

    void UpdateScore()
    {
        int displayScore = Mathf.FloorToInt(score);
        scoreText.text = displayScore.ToString("D" + digitCount);
    }

    // 🔥 PANGGIL SAAT GAME OVER
    public void SaveScoreOnGameOver()
    {
        int finalScore = Mathf.FloorToInt(score);

        PlayerPrefs.SetInt("LastScore", finalScore);

        int highScore = PlayerPrefs.GetInt("HighScore", 0);
        if (finalScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", finalScore);
        }

        PlayerPrefs.Save();
    }
}
