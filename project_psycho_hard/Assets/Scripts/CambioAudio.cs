using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioAudio : MonoBehaviour
{
     public AudioSource musica; // Audio que se detendrá
    public AudioSource postvieja; // Audio que se reproducirá

 private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra tiene el tag "Player"
        if (other.CompareTag("Player"))
        {
            // Detener el AudioSource "musica" si está reproduciéndose
            if (musica != null && musica.isPlaying)
            {
                musica.Stop();
            }

            // Reproducir el AudioSource "postvieja" si no está reproduciéndose
            if (postvieja != null && !postvieja.isPlaying)
            {
                postvieja.Play();
            }
        }
    }
}