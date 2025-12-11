using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public float volumeMusic = 1f;
    public float volumeSound = 1f;

    public Scrollbar scrollbarMusic;
    public Scrollbar scrollbarSound;

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AssignScrollbars();
        ApplySavedValues();
    }

    private void AssignScrollbars()
    {
        GameObject music = GameObject.FindGameObjectWithTag("Music");
        if (music != null)
            scrollbarMusic = music.GetComponent<Scrollbar>();

        GameObject sound = GameObject.FindGameObjectWithTag("Sound");
        if (sound != null)
            scrollbarSound = sound.GetComponent<Scrollbar>();
    }

    private void ApplySavedValues()
    {
        if (scrollbarMusic != null)
            scrollbarMusic.value = volumeMusic;

        if (scrollbarSound != null)
            scrollbarSound.value = volumeSound;
    }

    private void Update()
    {
        if (scrollbarMusic != null)
            volumeMusic = scrollbarMusic.value;

        if (scrollbarSound != null)
            volumeSound = scrollbarSound.value;
    }
}
