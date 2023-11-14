using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class player : MonoBehaviour
{

    public InventorySO inventory;

    public float maxHealth = 200, initialHungerState = 100, initialThirstState = 100, healthReducer = 1f;
    public float health, hunger, thirst, hungerIncreaseAmount = 2f, thirstIncreaseAmount = 3f;
    public bool isConsuming = false, isDead = false;
   
    
    void Start()
    {
        health = maxHealth;
        hunger = initialHungerState;
        thirst = initialThirstState;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        var obj = other.GetComponent<Items>();
        if (obj)
        {
            if (inventory.AddItem(obj.itemObj, 1))
            {
                Destroy(other.gameObject);
            }

        }
    }

    void Update()
    {
        if(!isConsuming && !isDead)
        {
            hunger -= hungerIncreaseAmount * Time.deltaTime;
            thirst -= thirstIncreaseAmount * Time.deltaTime;
            if(hunger <= 0 || thirst <= 0)
            {
                health -= healthReducer * Time.deltaTime;
                hunger = 0;
                thirst = 0;
            }
        }
        if(health <= 0)
        {
            died();
        }
    }


    void died()
    {
        isDead = true;
        Debug.Log("You have died!!");
        EditorApplication.isPlaying = false;
    }

    private void OnApplicationQuit()
    {
        Debug.Log("Inventory Reset!");
        
    }    
}
