using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llave : MonoBehaviour, IOperable
{
    private bool recogida = false; // Bandera para evitar múltiples recogidas

    public delegate void LlaveRecogidaHandler();
    public static event LlaveRecogidaHandler OnLlaveRecogida; // Evento global para notificar la recogida

    public void Operate() // Suponiendo que el jugador hace clic en la llave
    {
        if (!recogida)
        {
            recogida = true; // Marcamos la llave como recogida
            Debug.Log("Llave recogida!");

            // Notificamos a través del evento que se ha recogido una llave
            OnLlaveRecogida?.Invoke();

            // Opcional: Desactiva o destruye la llave
            gameObject.SetActive(false);
        }
        else
        {
            Debug.Log("Esta llave ya fue recogida.");
        }
    }
}
