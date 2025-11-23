using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject creditPanel;
    void Start()
    {
        settingsPanel.SetActive(false);
        creditPanel.SetActive(false);
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }
    
    public void settings()
    {
        settingsPanel.SetActive(true);
        creditPanel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void back()
    {
        settingsPanel.SetActive(false );
        creditPanel.SetActive(false);
    }

    public void Credit()
    {
        settingsPanel.SetActive(false);
        creditPanel.SetActive(true);
    }
}
