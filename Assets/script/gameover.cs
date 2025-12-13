using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    // public TextMeshProUGUI scoreText;
    // public TextMeshProUGUI highScoreText;

    void Start()
    {
        
        int lastScore = PlayerPrefs.GetInt("LastScore : ", 0);
        // int highScore = PlayerPrefs.GetInt("HighScore", 0);

        // scoreText.text =  lastScore.ToString();
        // highScoreText.text = highScore.ToString();
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }

    

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("main_menu");
    }

   
}
