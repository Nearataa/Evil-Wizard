using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathtrap : MonoBehaviour
{    
    private AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Spieler stirbt: Setze Coins zurück
            GameManager.Instance.ResetCoins();
            Audiomanager.Instance.PlayDeathSound();
            // Lade die Szene neu, um den Spieler zurückzusetzen
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
    
}