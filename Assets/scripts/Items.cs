using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public itemSO itemObj;  
    public float decreaseHungerBy = 10f;
    public float decreaseThirstBy = 20f;
    public float increaseHealthBy = 7f;


    private void OnTriggerEnter(Collider other)
    {

        var col = other.GetComponent<player>();
        if(col)
        {
            if (itemObj.consumable)
            {
                col.health += increaseHealthBy;
                col.hunger += decreaseHungerBy;
                col.thirst += decreaseThirstBy;
            }
        }
    }
}
