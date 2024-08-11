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
    private void Start()
    {
        settingsMenu = FindObjectOfType<SettingsMenu>();
        mainMenu = FindObjectOfType<MainMenu>();

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
        // You can also update the audio settings here
    }

    public void SetDanceDifficulty(int newDance)
    {
        danceDifficultyIndex = newDance;
        // You can apply difficulty settings here
    }

    public void SetSong(int newSong)
    {
        songIndex = newSong;
    }

    public AudioClip GetSongDifficulty()
    {
        AudioClip song = songs[songIndex%songs.Count-1];
        return song;
    }

    public PoseCollection GetDanceDifficulty()
    {
        PoseCollection poseCollection = poseCollections[danceDifficultyIndex%poseCollections.Count-1];


        return poseCollection;
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