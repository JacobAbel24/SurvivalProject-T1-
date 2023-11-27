using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    //private bool isPaused = false;
    public Canvas inventoryUI;
    public Transform slotHolder;
    private InventorySO inventory;

    InventorySlotUI[] slots;

    private void Start()
    {
        //inventoryUI = GetComponent<Canvas>();
        inventoryUI.enabled = false;

        slots = inventoryUI.GetComponentsInChildren<InventorySlotUI>();
        
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            InventoryUIToggle();
        }
    }

    void InventoryUIToggle()
    {

        //isPaused = !isPaused;
        inventoryUI.enabled = !inventoryUI.enabled;
        //Time.timeScale = isPaused ? 0 : 1;
    } 

    public void UpdateInventoryUI()
    {

        for(int i = 0; i < slots.Length; i++) 
        {
            if (i < inventory.container.Count)
            {
                slots[i].AddItemToUI(inventory.container[i].item);
            }
            else
            {
                slots[i].ClearItemFromUI();
            }
        }
    }
}
