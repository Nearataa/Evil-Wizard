using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    public static Audiomanager Instance { get; private set; }

    private AudioSource audioSource;
    public AudioClip backgroundMusic;
    public AudioClip portalSound;
    public AudioClip deathSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist AudioManager across scene loads
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate AudioManager instances
            return;
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Play background music
        PlayBackgroundMusic();
    }

    private void PlayBackgroundMusic()
    {
        if (backgroundMusic != null && audioSource != null)
        {
            audioSource.clip = backgroundMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    // Optional: Method to stop the background music
    public void StopBackgroundMusic()
    {
        if (audioSource != null)
        {
            audioSource.Stop();
        }
    }

    public void PlayDeathSound()
    {
        audioSource.PlayOneShot(deathSound);
    }

    public void PlayPortalSound()
    {
        audioSource.PlayOneShot(portalSound);
    }
}
