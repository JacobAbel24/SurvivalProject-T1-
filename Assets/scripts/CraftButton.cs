using UnityEngine;

public class CraftButton : MonoBehaviour
{
    public InventorySO inventory;
    InventorySlotUI[] slots;
    public Transform slotHolder;


    private void Start()
    {
        slots = slotHolder.GetComponentsInChildren<InventorySlotUI>();
    }
    // Craft the item if the player has the required ingredients
    public void CraftItem(RecipeSO recipe)
    {
        if (CanCraft(recipe))
        {
            // Craft the item
            inventory.AddItem(recipe.craftedItem, 1);

            // Remove consumed ingredients from the inventory
            ConsumeIngredients(recipe);

            //update the inventory UI
            UpdateInventoryUI();
            
        }
        else
        {
            Debug.Log("Crafting failed. Not enough ingredients.");
        }
    }

    // Check if the player has the required ingredients for crafting
    private bool CanCraft(RecipeSO recipe)
    {
        foreach (ItemSO requiredItem in recipe.item)
        {
            if (!inventory.HasEnoughItems(requiredItem, 1))
            {
                return false;
            }
        }
        return true;
    }

    // Remove consumed ingredients from the inventory
    private void ConsumeIngredients(RecipeSO recipe)
    {
        foreach (ItemSO requiredItem in recipe.item)
        {
            inventory.RemoveItem(requiredItem, 1);
        }
    }

    // Update the inventory UI (if needed)
    private void UpdateInventoryUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.container.Count)
            {
                // If there's an item in the inventory slot, update the UI
                slots[i].AddItemToUI(inventory.container[i].item, inventory.container[i].amount);
            }
            else
            {
                // If there's no item in the inventory slot, clear the UI
                slots[i].ClearItemFromUI();
            }
        }
    }
}
