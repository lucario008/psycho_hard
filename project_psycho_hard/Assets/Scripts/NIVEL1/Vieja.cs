using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vieja : MonoBehaviour, IOperable
{

    public TMPro.TextMeshProUGUI mensajeTexto;
    public string mensajeVieja;
    public float tiempoVisible;

    private int estadoVieja = 0;

    private enum Estado
    {
        PrimeraVez,
        Repetir,
        Desaparece
    }

    private Estado estadoActual;

    void Start()
    {
        estadoActual = Estado.PrimeraVez; // Estado inicial
    }

    public void ActualizarVieja(int estado)
    {
        estadoVieja = estado;
        switch (estadoVieja)
        {
            case 0:
                CambiarEstado(Estado.PrimeraVez);
                break;
            case 1:
                CambiarEstado(Estado.Repetir);
                break;
            case 2:
                CambiarEstado(Estado.Desaparece);
                break;
        }
    }

    private void CambiarEstado(Estado nuevoEstado)
    {
        if (estadoActual != nuevoEstado)
        {
            estadoActual = nuevoEstado;
            Debug.Log($"Estado de la puerta cambiado a: {estadoActual}");

            // Activar animaciones según el estado
            switch (estadoActual)
            {
                case Estado.PrimeraVez:
                    
                    break;

                case Estado.Repetir:
                    Debug.Log("Falta la medicina");
                    break;

                case Estado.Desaparece:
                    Debug.Log("Desapareciendo...");
                    break;
            }
        }
    }

    public void Operate()
    {
        if (estadoActual == Estado.PrimeraVez) { 

            mensajeVieja = "Quiero mis agujas";
            ActualizarTexto(mensajeVieja);
            StartCoroutine(DesaparecerTexto());

            CambiarEstado(Estado.Repetir);

        } else if (estadoActual == Estado.Repetir)
        {
            mensajeVieja = "¿Has encontrado ya las agujas?";
            ActualizarTexto(mensajeVieja);
            StartCoroutine(DesaparecerTexto());

            CambiarEstado(Estado.PrimeraVez);
        }

        
    }

 //********************************************* MENSAJES *************************************************

    private void ActualizarTexto(string mensaje)
    {
        if (mensajeTexto != null)
        {
            mensajeTexto.text = mensaje;
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
