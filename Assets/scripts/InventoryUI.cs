using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    //private bool isPaused = false;
    private Canvas inventoryUI;
    public List<InventorySO> inventory;



    private void Start()
    {
        inventoryUI = GetComponent<Canvas>();
        inventoryUI.enabled = false;
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


    
}
