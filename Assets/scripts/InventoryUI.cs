using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventoryUI : MonoBehaviour
{
    public Canvas inventoryUI;
    public Transform slotHolder;
    public InventorySO inventory;
    public PlayerControls playerControls;

    InventorySlotUI[] slots;

    private void Awake()
    {
        playerControls = new PlayerControls();
    }

    private void Start()
    {
        inventoryUI.enabled = false;
        slots = slotHolder.GetComponentsInChildren<InventorySlotUI>();

    }


    private void Update()
    {
        if (playerControls.playerMovementMap.InventoryToggle.triggered)
        {
            InventoryUIToggle();
        }

    }

    /// <summary>
    /// Toggles Inventory UI visibility On and Off.
    /// </summary>
    void InventoryUIToggle()
    {
        inventoryUI.enabled = !inventoryUI.enabled;
    }

    
    public bool PickUpItem(Items obj)
    {
        bool temp = inventory.AddItem(obj.itemObj, 1);
        UpdateInventoryUI();
        return temp;
    }

    public void UpdateInventoryUI()
    {

        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.container.Count)
            {
                slots[i].AddItemToUI(inventory.container[i].item, inventory.container[i].amount);
            }
            else
            {
                slots[i].ClearItemFromUI();
            }
        }
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

}
