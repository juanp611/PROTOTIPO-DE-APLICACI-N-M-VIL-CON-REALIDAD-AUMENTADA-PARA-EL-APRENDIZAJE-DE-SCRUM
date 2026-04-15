using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
        if (audioSource != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogError("No se encontró un AudioSource adjunto a este objeto.");
        }
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            SceneManager.LoadScene("InicioMultijugador");
        }
    }
}
