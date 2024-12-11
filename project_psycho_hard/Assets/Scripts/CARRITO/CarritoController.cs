using System.Collections.Generic;
using UnityEngine;

public class CarritoController : MonoBehaviour
{
    public List<string> objetosEnCarrito; // Lista de objetos en el carrito
    public GameObject hudCarrito;        // Referencia al HUD del carrito

    private bool jugadorCerca = false;

    void Start()
    {
        objetosEnCarrito = new List<string>();
        if (hudCarrito != null)
            hudCarrito.SetActive(false); // Oculta el HUD al inicio
    }

    void Update()
    {
        // Detectar interacción con el carrito
        if (jugadorCerca && Input.GetKeyDown(KeyCode.K))
        {
            MostrarHUDCarrito();
        }
    }

    void MostrarHUDCarrito()
    {
        if (hudCarrito != null)
        {
            hudCarrito.SetActive(true); // Activa o desactiva el HUD
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
            if (hudCarrito != null)
                hudCarrito.SetActive(false); // Oculta el HUD cuando el jugador se aleja
        }
    }
}