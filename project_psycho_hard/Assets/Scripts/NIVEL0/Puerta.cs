using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Puerta : MonoBehaviour, IOperable
{

    private Animator anim;
    private bool open;

    public TMPro.TextMeshProUGUI mensajeTexto;
    public string mensajePuerta;
    public float tiempoVisible = 2f; 
    private enum Estado
    {
        Cerrada,
        Llave1Insertada,
        Llave2Insertada,
        Abierta
    }

    private Estado estadoActual;
    private Animator animator;
    private int llavesRecogidas = 0; // Controlador de animaciones

    void Start()
    {
        estadoActual = Estado.Cerrada; // Estado inicial
    
        Debug.Log("Estado inicial de la puerta: Cerrada");

         anim = GetComponentInParent<Animator>();
         open = anim.GetBool("Open");
    } 

    // Método para actualizar el estado según el número de llaves
   public void ActualizarLlaves(int llaves)
    {
        llavesRecogidas = llaves;
        switch (llavesRecogidas)
        {
            case 0:
                CambiarEstado(Estado.Cerrada);
                break;
            case 1:
                CambiarEstado(Estado.Llave1Insertada);
                break;
            case 2:
                CambiarEstado(Estado.Llave2Insertada);
                break;
        }
    }

   public void Operate()
    {
        if (estadoActual == Estado.Llave2Insertada)
        {
            AbrirPuerta();
        } else if (estadoActual == Estado.Abierta){
            open = !open;
            anim.SetBool("Open", open);
        }
        else
        {
          //  Debug.Log("La puerta no puede abrirse.");

            mensajePuerta = "Cerrada. Necesito dos llaves, estaban en su despacho.";
                    ActualizarTexto(mensajePuerta); 
                    StartCoroutine(DesaparecerTexto());
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
                case Estado.Cerrada:
                   // Debug.Log("Cerrada. Necesito 2 llaves");
                    break;
                case Estado.Llave1Insertada:
                   // Debug.Log("Falta 1 llave");
                    mensajePuerta = "¡Una llave! Falta otra.";
                    ActualizarTexto(mensajePuerta); 
                    StartCoroutine(DesaparecerTexto());
                    break;
                case Estado.Llave2Insertada:
                   // Debug.Log("Desbloqueada!");
                    mensajePuerta = "Aquí hay otra llave. Con esto debería valer.";
                    ActualizarTexto(mensajePuerta); 
                    StartCoroutine(DesaparecerTexto());
                    break;
                case Estado.Abierta:
                    open = !open;
                    anim.SetBool("Open", open);
                    break;
            }
        }
    }

//********************************************* SISTEMA PUERTA *****************************************
    public void AbrirPuerta()
    {
        CambiarEstado(Estado.Abierta);
        Debug.Log("¡Puerta abierta!");
    }

    public void CerrarPuerta()
    {
        open = !open;
        anim.SetBool("Open", open); // Cambia el estado de la puerta a cerrada

        Debug.Log("La puerta está cerrándose...");
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