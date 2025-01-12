using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public string itemName;

    private InventorySystem inventorySystem;

    private void Start()
    {
        inventorySystem = FindObjectOfType<InventorySystem>();  // Encuentra el sistema de inventario
    }

    private void OnMouseDown()
    {
        if (inventorySystem != null)
        {
            // Si no hay nada en el bolsillo o el objeto es del mismo tipo, se puede recoger
            if (!inventorySystem.HasItemInPocket() || inventorySystem.GetPocketItemName() == itemName)
            {
                inventorySystem.AddToPocket(itemName); // Agregar el objeto al bolsillo
                Debug.Log("Objeto agregado al bolsillo: " + itemName);
                Destroy(gameObject); // Destruir el objeto en la escena
            }
            else
            {
                Debug.Log("El bolsillo ya contiene otro objeto.");
            }
        }
    }
}
