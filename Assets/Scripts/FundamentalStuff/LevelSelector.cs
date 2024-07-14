using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
 
    public Button[] buttons;

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }
        for (int i = 0; i < unlockedLevel; i++)
        {
            buttons[i].interactable = true;
        }
    }
    public void OpenScene(int level)
    {
        Time.timeScale = 1f;
        string levelName = "Level " + level;
        SceneManager.LoadScene(levelName);
    }

    public void OpenMenu()
    {

        GameManager.Instance.ResetCoins();
        string levelName = "MainMenu";
        Time.timeScale = 1f;
        GameManager.Instance.LoadScene(levelName);
    }
}
