using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Inventory")]
public class InventorySO : ScriptableObject
{
    public List<InventorySlot> container = new List<InventorySlot>();
    [SerializeField]
    public int maxSlots = 10;

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