using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class Vieja : MonoBehaviour, IOperable
{
    [SerializeField] private RecogerMedicamento medic;

    public TMPro.TextMeshProUGUI mensajeTexto;
    public string mensajeVieja;
    public float tiempoVisible;

    private int estadoVieja = 0;

   public  GameObject mensajeNoVieja;
   public  GameObject finDemo;

    private enum Estado
    {
        PrimeraVez,
        Repetir,
        Desaparece
    }

    private Estado estadoActual;

    public GameObject objetoNecesario;

    void Start()
    {
        estadoActual = Estado.PrimeraVez; // Estado inicial
        mensajeNoVieja.SetActive(false);
        finDemo.SetActive(false);
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
                    break;

                case Estado.Desaparece:
                    Debug.Log("Desapareciendo...");
                                                         
                    break;
            }
        }
       


    }

    public void Operate()
    {
        
        if (estadoActual == Estado.PrimeraVez)
        {
            mensajeVieja = "Quiero mis agujas";
            ActualizarTexto(mensajeVieja);
            StartCoroutine(DesaparecerTexto());
            CambiarEstado(Estado.Repetir);
        }
        else if (estadoActual == Estado.Repetir)
        {
            mensajeVieja = "¿Has encontrado ya las agujas?";
            ActualizarTexto(mensajeVieja);
            StartCoroutine(DesaparecerTexto());
            CambiarEstado(Estado.PrimeraVez);
        }

        if (medic.objetoRecogido) // Se verifica antes de cambiar el estado
        {
          CambiarEstado(Estado.Desaparece); // Cambia al estado 2
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (medic.objetoRecogido)
        {
            if (mensajeTexto != null)
            {
                mensajeTexto.text = "";
            }

            mensajeNoVieja.SetActive(true);
            finDemo.SetActive(true);

            gameObject.SetActive(false);    
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
