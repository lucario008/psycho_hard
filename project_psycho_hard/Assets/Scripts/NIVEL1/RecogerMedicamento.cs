using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecogerMedicamento : MonoBehaviour, IOperable
{
    [SerializeField] private Vieja vieja;

    public TMPro.TextMeshProUGUI mensajeTexto;
    public string mensaje;

    public float tiempoVisible = 2f;


    public bool objetoRecogido = false;
    // Start is called before the first frame update
    public void Operate()
    {
        if (!objetoRecogido) // Evita que se repita la acción
        {
            if (vieja.objetoNecesario != null)
            {
                objetoRecogido = true; // Marca que el objeto ha sido recogido
                Destroy(vieja.objetoNecesario); // Elimina el objeto del juego
                Debug.Log("Objeto recogido: " + vieja.objetoNecesario.name);

                mensajeTexto.text = mensaje;
               
            }
            else
            {
                Debug.LogError("Error: El objeto necesario no está asignado en la Vieja.");
            }
        }

    }

}
