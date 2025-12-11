using UnityEngine;
using UnityEngine.SceneManagement;

public class gameover : MonoBehaviour
{
    

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
