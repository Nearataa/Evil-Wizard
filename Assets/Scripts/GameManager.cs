using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Text coinText; // Referenz zum UI-Text-Element
    private int coinCount = 0;

    private int level = 0; // Beispiel für die Levelnummer

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
        }
    }

    private void Start()
    {
        LoadGame();
        UpdateCoinText();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        coinText = GameObject.FindWithTag("CoinText")?.GetComponent<Text>();
        UpdateCoinText();
    }

    public void IncreaseCoinCount()
    {
        coinCount++;
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = "Coins: " + coinCount.ToString();
        }
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("CoinCount", coinCount);
        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("CoinCount"))
        {
            coinCount = PlayerPrefs.GetInt("CoinCount");
        }
    }

    public void LoadNextScene()
    {
        // Beispiel: Lade die nächste Szene basierend auf dem aktuellen Level
        level++;
        SceneManager.LoadScene("Level " + level.ToString());
    }

    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void ResetCoins()
    {
        coinCount = 0;
        UpdateCoinText();
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }
}