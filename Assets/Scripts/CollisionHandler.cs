using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] AudioClip successSound;
    [SerializeField] AudioClip deathSound;
    [SerializeField] ParticleSystem successParticles;
    [SerializeField] ParticleSystem deathParticles;
    AudioSource audioSource;

    bool isTransitioning = false;
    internal bool enableCollisions = true;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        if (enableCollisions)
        {
            switch (other.gameObject.tag)
            {
                case "Respawn":
                    Debug.Log("Not a problem.");
                    break;
                case "powerup":
                    break;
                case "Finish":
                    FinishSequence();
                    break;
                default:
                    RestartSequence();
                    break;
            }
        }
    }

    private void RestartSequence()
    {
        if (isTransitioning == false)
        {
            isTransitioning = true;
            StopMovement();
            audioSource.PlayOneShot(deathSound);
            deathParticles.Play();
            Invoke("RestartLevel", 3f);
        }
    }

    private void FinishSequence()
    {
        if (isTransitioning == false)
        {
            isTransitioning = true;
            StopMovement();
            audioSource.PlayOneShot(successSound);
            successParticles.Play();
            Invoke("LoadNextLevel", 3f);
        }
    }

    private void StopMovement()
    {
        GetComponent<PlayerMovement>().enabled = false;
    }

    public void LoadNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex < 2)
        {
            Debug.Log((SceneManager.GetActiveScene().buildIndex + 1));
            SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1));
        }
        else
        {
            Debug.Log("Restarting");
            SceneManager.LoadScene(0);
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
