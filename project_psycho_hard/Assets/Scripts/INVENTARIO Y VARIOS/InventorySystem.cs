using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventorySystem : MonoBehaviour
{
    [SerializeField] private GameObject cartPanel;
    [SerializeField] private TMP_Text pocketText;
    [SerializeField] private TMP_Text cartText;
    [SerializeField] private CarInteractionZone carInteractionZone;

    private PocketInventory pocket;
    private CartInventory cart;

    private int selectedCartItemIndex = 0; // Índice de item seleccionado en el carrito

    private void Start()
    {
        pocket = new PocketInventory();
        cart = new CartInventory();
        UpdateUI();
        cartPanel.SetActive(false); // Asegúrate de que el panel del carrito esté oculto al inicio
    }

    private void Update()
    {
        // Si el jugador está cerca del carrito y presiona I, mostrar/ocultar el carrito
        if (Input.GetKeyDown(KeyCode.I) && CanInteractWithCart())
        {
            ToggleCartUI();
        }

        if (cartPanel.activeSelf)
        {

            // Navegar entre los objetos del carrito
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                selectedCartItemIndex = Mathf.Max(selectedCartItemIndex - 1, 0); // Mover arriba
                UpdateUI();
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                selectedCartItemIndex = Mathf.Min(selectedCartItemIndex + 1, cart.GetItemCount() - 1); // Mover abajo
                UpdateUI();
            }

            // Si el jugador presiona "F", mover el objeto seleccionado
            if (Input.GetKeyDown(KeyCode.G))
            {
                MoveToPocketFromCart();
            }
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            MoveToCart();
        }
    }

    private bool CanInteractWithCart()
    {
        return carInteractionZone != null && carInteractionZone.IsPlayerInRange();
    }

    private void ToggleCartUI()
    {
        cartPanel.SetActive(!cartPanel.activeSelf);
        UpdateUI();
    }

    public void AddToPocket(string itemName)
    {
        if (pocket.HasItem() && pocket.GetItemName() == itemName)
        {
            pocket.AddItem(itemName); // Si ya tiene el mismo objeto, acumula
        }
        else if (!pocket.HasItem())
        {
            pocket.AddItem(itemName); // Si el bolsillo está vacío, añade
        }
        UpdateUI();
    }

    public void MoveToCart()
    {
        if (pocket.HasItem())
        {
            string itemName = pocket.GetItemName();
            cart.AddItem(itemName); // Mover el objeto del bolsillo al carrito
            pocket.RemoveItem(); // Eliminarlo del bolsillo
            UpdateUI();
        }
    }

    public void MoveToPocketFromCart()
    {
        // Obtener el objeto seleccionado del carrito
        string selectedItem = cart.GetItemAt(selectedCartItemIndex);

        if (!pocket.HasItem() || pocket.GetItemName() == selectedItem)
        {
            // Reducir la cantidad del objeto en el carrito
            cart.RemoveSingleItem(selectedItem);

            // Agregar una unidad del objeto al bolsillo
            pocket.AddItem(selectedItem);

            // Actualizar la interfaz gráfica
            UpdateUI();
        }
    }


    private void UpdateUI()
    {
        // Actualizar los textos de bolsillo y carrito
        pocketText.text = pocket.GetInventoryText();
        cartText.text = cart.GetInventoryText(selectedCartItemIndex);
    }

    // Métodos públicos para interactuar con el PocketInventory
    public bool HasItemInPocket()
    {
        return pocket.HasItem();
    }

    public string GetPocketItemName()
    {
        return pocket.GetItemName();
    }
}


[System.Serializable]
public class Item
{
    public string name;
    public int quantity;

    public Item(string name, int quantity = 1)
    {
        this.name = name;
        this.quantity = quantity;
    }
}

public class PocketInventory
{
    private Item pocketItem;

    public string GetItemName()
    {
        return pocketItem?.name;
    }

    public void AddItem(string itemName)
    {
        if (pocketItem == null)
        {
            pocketItem = new Item(itemName);
        }
        else if (pocketItem.name == itemName)
        {
            pocketItem.quantity++;
        }
    }

    public Item RemoveItem()
    {
        if (pocketItem != null)
        {
            var item = pocketItem;
            pocketItem = null;
            return item;
        }
        return null;
    }

    public bool HasItem()
    {
        return pocketItem != null;
    }

    public string GetInventoryText()
    {
        if (pocketItem == null) return "Bolsillo vacío";
        return $"{pocketItem.name} x{pocketItem.quantity}";
    }
}

public class CartInventory
{
    private List<Item> cartItems = new List<Item>();


    public void RemoveSingleItem(string itemName)
    {
        var item = cartItems.Find(i => i.name == itemName);
        if (item != null)
        {
            item.quantity--; // Reducir la cantidad
            if (item.quantity <= 0)
            {
                cartItems.Remove(item); // Eliminar el objeto si su cantidad es 0
            }
        }
    }

    public void AddItem(string itemName, int quantity = 1)
    {
        var item = cartItems.Find(i => i.name == itemName);
        if (item != null)
        {
            item.quantity += quantity;
        }
        else
        {
            cartItems.Add(new Item(itemName, quantity));
        }
    }

    public bool RemoveItem(string itemName)
    {
        var item = cartItems.Find(i => i.name == itemName);
        if (item != null)
        {
            cartItems.Remove(item);
            return true;
        }
        return false;
    }

    public string GetInventoryText(int selectedItemIndex)
    {
        if (cartItems.Count == 0) return "Carrito vacío";
        string result = "";
        for (int i = 0; i < cartItems.Count; i++)
        {
            result += (i == selectedItemIndex ? "> " : "") + $"{cartItems[i].name} x{cartItems[i].quantity}\n";
        }
        return result;
    }

    public int GetItemCount()
    {
        return cartItems.Count;
    }

    public string GetItemAt(int index)
    {
        if (index >= 0 && index < cartItems.Count)
        {
            return cartItems[index].name;
        }
        return null;
    }
}
