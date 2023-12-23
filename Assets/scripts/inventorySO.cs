using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Inventory")]
public class InventorySO : ScriptableObject
{
    public List<InventorySlot> container = new List<InventorySlot>();
    [SerializeField]
    public int maxSlots = 10;
    /// <summary>
    /// Adds item to the inventory.
    /// </summary>
    /// <param name="_item">Resource Item</param>
    /// <param name="_amount">Number of items</param>
    /// <returns></returns>
    public bool AddItem(ItemSO _item, int _amount)
    {
        for (int i = 0; i < container.Count; i++)
        {
            if (container[i].item == _item)
            {
                container[i].addAmount(_amount);
                return true;
            }
        }
           

        if (container.Count < maxSlots)
        {
            container.Add(new InventorySlot(_item, _amount));
            
            return true;
        }

        return false;
    }

    /// <summary>
    /// Checks if the inventory has enough items for crafting.
    /// </summary>
    /// <param name="item">Resource item in the crafting slots</param>
    /// <param name="amount">Number of items</param>
    /// <returns></returns>
    public bool HasEnoughItems(ItemSO item, int amount)
    {
        foreach (InventorySlot slot in container)
        {
            if (slot.item == item && slot.amount >= amount)
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Removes item from the inventory.
    /// </summary>
    /// <param name="item">Resource Item</param>
    /// <param name="amount">Number of items</param>
    public void RemoveItem(ItemSO item, int amount)
    {
        for (int i = 0; i < container.Count; i++)
        {
            InventorySlot slot = container[i];
            if (slot.item == item)
            {

                if (slot.amount >= amount)
                {
                    slot.amount -= amount;

                    if (slot.amount <= 0)
                    {
                        container.RemoveAt(i);
                    }
                    return;
                }
            }
        }
    }

}

[System.Serializable]
public class InventorySlot
{
    public ItemSO item;
    public int amount;
    public InventorySlot(ItemSO _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }
    public void addAmount(int value)
    {
        amount += value;
    }
}