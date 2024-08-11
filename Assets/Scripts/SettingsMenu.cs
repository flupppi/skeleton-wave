using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public void SetSpeedDifficulty(int newSpeed)
    {
        GameManager.Instance.SetSpeedDifficulty(newSpeed);  
    }

    public void SetDanceDifficulty(int newDance)
    {
        GameManager.Instance.SetDanceDifficulty(newDance);
    }

    public void SetSong(int newSong)
    {
        GameManager.Instance.SetSong(newSong);
    }
    public void ShowMainMenu()
    {
        GameManager.Instance.ShowMainMenu();
    }
}
