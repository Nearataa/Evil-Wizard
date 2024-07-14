using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollision : MonoBehaviour
{
    public AudioClip coinCollectSound; // Reference to the coin collect sound
    private AudioSource audioSource;
    
    private void Start()
    {
        audioSource = GameObject.FindWithTag("Player")?.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            Debug.LogError("AudioSource component is missing from the player.");
        }

        if (coinCollectSound == null)
        {
            Debug.LogError("Coin collect sound is not assigned in the inspector.");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.PlayOneShot(coinCollectSound);
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.IncreaseCoinCount();
            Destroy(gameObject);
        }
    }
}
