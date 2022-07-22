using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] float mainThrust = 1000f;
    [SerializeField] float rotateSpeed = 300f;
    [SerializeField] ParticleSystem leftThrusterParticles;
    [SerializeField] ParticleSystem bottomThrusterParticles;
    [SerializeField] ParticleSystem rightThrusterParticles;

    AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
            if (!bottomThrusterParticles.isPlaying)
            {
                bottomThrusterParticles.Play();
            }
        }
        ProcessAudio();
    }

    private void ProcessAudio()
    {
        if (Input.GetKey(KeyCode.Space) && !audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            audioSource.Stop();
            bottomThrusterParticles.Stop();
        }
    }

    void ProcessRotation()
    {
        rb.freezeRotation = true;
        StartParticlesAndMovement();
        StopParticles();
        rb.freezeRotation = false;
    }

    private void StartParticlesAndMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
            if (!rightThrusterParticles.isPlaying)
            {
                rightThrusterParticles.Play();
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * rotateSpeed * Time.deltaTime);
            if (!leftThrusterParticles.isPlaying)
            {
                leftThrusterParticles.Play();
            }
        }
    }

    private void StopParticles()
    {
        if (Input.GetKeyUp(KeyCode.A))
        {
            rightThrusterParticles.Stop();
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            leftThrusterParticles.Stop();
        }
    }
}
