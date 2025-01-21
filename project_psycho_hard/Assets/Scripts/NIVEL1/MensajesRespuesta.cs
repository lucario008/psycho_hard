using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MensajesRespuesta : MonoBehaviour
{
    public string mensajeFijo; // Mensaje que se mostrará
    public TMPro.TextMeshProUGUI mensajeTexto; // Objeto de texto para mostrar el mensaje
    public AudioSource audioSource; // AudioSource que debe reproducirse antes del mensaje
    public float tiempoVisible = 2f; // Tiempo que el mensaje permanecerá visible

    public void Operate()
    {
        if (audioSource != null)
        {
            audioSource.Play(); // Reproduce el audio
            StartCoroutine(MostrarMensajeDespuesDelAudio()); // Espera a que el audio termine
        }
        else
        {
            Debug.LogWarning("No se asignó un AudioSource. Mostrando mensaje inmediatamente.");
            MostrarMensaje();
        }
    }

    private IEnumerator MostrarMensajeDespuesDelAudio()
    {
        yield return new WaitWhile(() => audioSource.isPlaying); // Espera hasta que el audio termine
        MostrarMensaje();
    }

    private void MostrarMensaje()
    {
        if (mensajeTexto != null)
        {
            mensajeTexto.text = mensajeFijo; // Muestra el mensaje fijo
            StartCoroutine(DesaparecerTexto()); // Borra el texto después de un tiempo
        }
    }

    private IEnumerator DesaparecerTexto()
    {
        yield return new WaitForSeconds(tiempoVisible);
        if (mensajeTexto != null)
        {
            mensajeTexto.text = ""; // Borra el mensaje
        }
    }

}
