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

