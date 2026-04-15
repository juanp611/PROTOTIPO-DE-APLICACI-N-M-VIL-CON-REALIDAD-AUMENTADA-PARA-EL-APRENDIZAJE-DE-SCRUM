using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayAudioOnObjectDetection : MonoBehaviour
{
    public AudioSource audioSource; // Asigna el AudioSource desde el Inspector
    public GameObject markerObject; // Asigna el marcador o un objeto activador

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == markerObject && !audioSource.isPlaying)
        {
            audioSource.Play();
            StartCoroutine(WaitForAudioEnd());
        }
    }

    private IEnumerator WaitForAudioEnd()
    {
        while (audioSource.isPlaying)
        {
            yield return null;
        }
        SceneManager.LoadScene("InicioMultijugador");
    }
}