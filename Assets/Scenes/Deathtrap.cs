using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathtrap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Spieler stirbt: Setze Coins zurück
            GameManager.Instance.ResetCoins();
            
            // Optional: Füge hier weitere Aktionen hinzu, z.B. Soundeffekte, Animationen usw.

            // Lade die Szene neu, um den Spieler zurückzusetzen
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}