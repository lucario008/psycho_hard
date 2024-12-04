using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPuerta : MonoBehaviour
{
    
    private int contadorLlaves = 0; // Contador de llaves recogidas
    private int llavesNecesarias = 2; // Total de llaves necesarias para abrir la puerta
    
    [SerializeField] private Puerta puerta; // Referencia al script de la puerta
    
    void OnEnable()
    {
        // Suscribimos el método al evento de recogida de llaves
        Llave.OnLlaveRecogida += IncrementarContador;
    }

    void OnDisable()
    {
        // Desuscribimos el método para evitar errores al destruir objetos
        Llave.OnLlaveRecogida -= IncrementarContador;
    }

    private void IncrementarContador()
    {
        contadorLlaves++;
         Debug.Log($"Llaves recogidas: {contadorLlaves}");

          puerta.ActualizarLlaves(contadorLlaves);

        if (contadorLlaves >= llavesNecesarias)
        {
            Debug.Log("¡Se puede abrir la puerta!");
            // Aquí puedes llamar a tu lógica para abrir la puerta.
        }
    }
}
