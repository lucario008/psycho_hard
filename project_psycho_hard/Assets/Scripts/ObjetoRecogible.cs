using UnityEngine;

public class ObjetoInteractivo : MonoBehaviour
{
    public string nombreObjeto; // Nombre del objeto

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            CarritoController carrito = FindObjectOfType<CarritoController>();
            if (carrito != null)
            {
                carrito.objetosEnCarrito.Add(nombreObjeto);
                Destroy(gameObject);
            }
        }
    }
}