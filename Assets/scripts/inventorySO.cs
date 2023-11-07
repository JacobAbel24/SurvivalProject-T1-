using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory")]
public class Inventory : ScriptableObject
{
    public List<itemSO> items = new List<itemSO>();

    public void AddItem(itemSO item)
    {
       
    }

    public void RemoveItem(itemSO item)
    {
       
    }
}
/*Created empty undefined inventory (will be defined later, remve list and make it using arrays, 10 slots)
create item templates
define a few items and craftables
when the character interacts with an item, it DESTROYS the instance of that item from the gamescene and adds that item type in the inventory.
addItem function
when the inventory fills up, dont add any more items (show message)
make a basic Inventory UI (later) update accordingly with the script


removeItem function, delete the item from the inventory*/
