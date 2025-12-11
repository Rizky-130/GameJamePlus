using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject pausePanel;

    private bool isPaused = false;

    void Start()
    {
        settingsPanel.SetActive(false);
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    public void Retry()
    {
        Time.timeScale = 1; 
        SceneManager.LoadScene("SampleScene");
    }

    public void Settings()
    {
        settingsPanel.SetActive(true);
        pausePanel.SetActive(false );
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("main_menu");
    }

    public void Back()
    {
        settingsPanel.SetActive(false);
        pausePanel.SetActive(true );
    }
}
