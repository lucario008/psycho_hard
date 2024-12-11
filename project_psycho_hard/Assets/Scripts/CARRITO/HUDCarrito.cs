using UnityEngine;
using TMPro;

public class HUDCarritoController : MonoBehaviour
{
    public CarritoController carritoController; // Carrito
    public TextMeshProUGUI textoInventario;     // Nombre de los objetos

    void OnEnable()
    {
        ActualizarHUD();
    }

    public void ActualizarHUD()
    {
        if (textoInventario != null && carritoController != null)
        {
            textoInventario.text = "El carrito contiene:\n";

            foreach (var objeto in carritoController.objetosEnCarrito)
            {
                textoInventario.text += $"- {objeto}\n";
            }
        }
    }
}
