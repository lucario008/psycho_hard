using UnityEngine;

public class CarInteractionZone : MonoBehaviour
{
    private bool playerInRange = false;
    private InventorySystem playerInventory;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Asegúrate de que el jugador tenga el tag "Player"
        {
            playerInRange = true;
            playerInventory = other.GetComponent<InventorySystem>(); // Referencia al inventario del jugador
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            playerInventory = null; // Limpia la referencia
        }
    }

    public bool IsPlayerInRange()
    {
        return playerInRange;
    }
}
