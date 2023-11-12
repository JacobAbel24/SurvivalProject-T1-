using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory")]
public class InventorySO : ScriptableObject
{
    public List<inventorySlot> container = new List<inventorySlot>();

    public void AddItem(itemSO _item, int _amount)
    {
        bool hasItem = false;
        for(int i = 0; i < container.Count; i++)
        {
            if (container[i].item == _item) 
            {
                container[i].addAmount(_amount);
                hasItem = true;
                break;
            }
        }
        if (!hasItem)
        {
            container.Add(new inventorySlot(_item, _amount));
        }
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
Created empty undefined inventory (will be defined later, remve list and make it using arrays, 10 slots)
create item templates
define a few items and craftables
when the character interacts with an item, it DESTROYS the instance of that item from the gamescene and adds that item type in the inventory.
addItem function
when the inventory fills up, dont add any more items (show message)
make a basic Inventory UI (later) update accordingly with the script


removeItem function, delete the item from the inventory
*/
