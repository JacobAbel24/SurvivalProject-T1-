using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory")]
public class InventorySO : ScriptableObject
{
    public List<inventorySlot> container = new List<inventorySlot>();
    private int maxSlots = 6;

    public bool AddItem(itemSO _item, int _amount)
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
            container.Add(new inventorySlot(_item, _amount));
            return true;
        }

        return false;
    }

}

[System.Serializable]
public class inventorySlot
{
    public itemSO item;
    public int amount;
    public inventorySlot(itemSO _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }
    public void addAmount(int value)
    {
        amount += value;
    }
}
/*
Created empty undefined inventory (will be defined later, remve list and make it using arrays, 10 slots or restrict the list to 10 max)
when the inventory fills up, dont add any more items (show message)
make a basic Inventory UI (later) update accordingly with the script
removeItem function, delete the item from the inventory
*/
