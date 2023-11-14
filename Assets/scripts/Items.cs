using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public itemSO itemObj;
    public float decreaseHungerBy = 10f;
    public float decreaseThirstBy = 20f;




    private void OnTriggerEnter(Collider other)
    {

        var col = other.GetComponent<player>();
        if(col)
        {
            if (itemObj.consumable)
            {
                col.hunger += decreaseHungerBy;
                col.thirst += decreaseThirstBy;
            }
        }
    }

    
}
