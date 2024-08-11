using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton instance
    public static GameManager Instance { get; private set; }

    // Variables to store settings (you can add more as needed)
    public int danceDifficultyIndex = 0;
    public List<PoseCollection> poseCollections = new List<PoseCollection>();

    public int songIndex = 0;
    public List<AudioClip> songs = new List<AudioClip>();

    public int speedDifficultyIndex = 0;

    public SettingsMenu settingsMenu;
    public MainMenu mainMenu;

    private void Awake()
    {
        // Implementing the singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // This GameObject won't be destroyed when loading a new scene
        }
    }

    private void OnEnable()
    {
        // Register the callback to be called every time a scene is loaded
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        // Unregister the callback
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Reassign references to the menus whenever a scene is loaded
        settingsMenu = FindObjectOfType<SettingsMenu>();
        mainMenu = FindObjectOfType<MainMenu>();

        // Optionally, you can set the settings menu to inactive when the scene loads
        settingsMenu?.gameObject.SetActive(false);
    }

    // Method to quit the application
    public void QuitGame()
    {
        Debug.Log("Game is quitting...");
        Application.Quit();
    }

    // Method to load the main menu
    public void LoadMainMenu()
    {
        // Assuming your main menu is in scene index 0
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    // Add more methods to store and retrieve settings as needed
    public void SetSpeedDifficulty(int newSpeed)
    {
        speedDifficultyIndex = newSpeed;
    }

    public void SetDanceDifficulty(int newDance)
    {
        danceDifficultyIndex = newDance;
    }

    public void SetSong(int newSong)
    {
        songIndex = newSong;
    }

    public AudioClip GetSongDifficulty()
    {
        return songs[songIndex];
    }

    public PoseCollection GetDanceDifficulty()
    {
        return poseCollections[danceDifficultyIndex];
    }

    public void ShowSettingsMenu()
    {
        if (mainMenu != null && settingsMenu != null)
        {
            mainMenu.gameObject.SetActive(false);
            settingsMenu.gameObject.SetActive(true);
        }
    }

    public void ShowMainMenu()
    {
        if (mainMenu != null && settingsMenu != null)
        {
            settingsMenu.gameObject.SetActive(false);
            mainMenu.gameObject.SetActive(true);
        }
    }
}
