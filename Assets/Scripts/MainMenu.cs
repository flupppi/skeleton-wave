using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.StartGame();
    }
    public void QuitGame()
    {
        GameManager.Instance.QuitGame();
    }

    public void Settings()
    {
        GameManager.Instance.ShowSettingsMenu();
    }
}
