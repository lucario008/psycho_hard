using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Llave : MonoBehaviour, IOperable
{
    private bool recogida = false; // Bandera para evitar múltiples recogidas

    public delegate void LlaveRecogidaHandler();
    public static event LlaveRecogidaHandler OnLlaveRecogida; // Evento global para notificar la recogida

    public TMPro.TextMeshProUGUI mensajeTexto;
    public string mensaje = "Ya no hay nada más.";
    public float tiempoVisible = 2f; 

    public void Operate() // Suponiendo que el jugador hace clic en la llave
    {
        if (!recogida)
        {
            recogida = true; // Marcamos la llave como recogida
            Debug.Log("Llave recogida!");

            // Notificamos a través del evento que se ha recogido una llave
            OnLlaveRecogida?.Invoke();

            // Opcional: Desactiva o destruye la llave
           // gameObject.SetActive(false);
        }
        else
        {
            mensajeTexto.text = mensaje; // Muestra el mensaje fijo
            StartCoroutine(DesaparecerTexto());
            Debug.Log("Esta llave ya fue recogida.");
        }
    }

    private IEnumerator DesaparecerTexto()
    {
        yield return new WaitForSeconds(tiempoVisible);
        if (mensajeTexto != null)
        {
            mensajeTexto.text = "";
        }
    }
}
