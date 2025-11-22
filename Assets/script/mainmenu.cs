using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    void Start()
    {
        settingsPanel.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
    public void settings()
    {
        settingsPanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void back()
    {
        settingsPanel.SetActive(false );
    }
}
