using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public TextMeshProUGUI coinText; // Reference to the UI text element
    private int coinCount = 0;

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
        // Find the new coinText object in the loaded scene
        coinText = GameObject.FindWithTag("CoinText")?.GetComponent<TextMeshProUGUI>();
        // Update the text to reflect the current coin count
        UpdateCoinText();
    }

    public void IncreaseCoinCount()
    {
        coinCount++;
        UpdateCoinText();
    }

    private void UpdateCoinText()
    {
        coinText.text = "Coins: " + coinCount.ToString();
    }

    public void ResetCoins()
    {
        coinCount = 0;
        UpdateCoinText();
    }
}
