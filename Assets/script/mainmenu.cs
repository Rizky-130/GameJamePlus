using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    public GameObject creditPanel;
    public GameObject htpPanel;
    void Start()
    {
        settingsPanel.SetActive(false);
        creditPanel.SetActive(false);
        htpPanel.SetActive(false);  
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void htp()
    {   htpPanel.SetActive(true);
        settingsPanel.SetActive(false);
        creditPanel.SetActive(false);
    }
    public void settings()
    {   htpPanel.SetActive(false);
        settingsPanel.SetActive(true);
        creditPanel.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void back()
    {   htpPanel.SetActive(false);
        settingsPanel.SetActive(false );
        creditPanel.SetActive(false);
    }

    public void Credit()
    {   htpPanel.SetActive(false);
        settingsPanel.SetActive(false);
        creditPanel.SetActive(true);
    }
}
