using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class player : MonoBehaviour
{
    public float maxHealth = 200, hungerMeter = 100, thirstMeter = 100, healthReducer = 1f;
    public float health, hunger, thirst, hungerIncreaseAmount = 2f, thirstIncreaseAmount = 3f;
    public bool isConsuming = false, isDead = false;
    void Start()
    {
        health = maxHealth;
        hunger = hungerMeter;
        thirst = thirstMeter;
    }


    void Update()
    {
        if(!isConsuming && !isDead)
        {
            hunger -= hungerIncreaseAmount * Time.deltaTime;
            thirst -= thirstIncreaseAmount * Time.deltaTime;
            if(hunger < hungerMeter || thirst < thirstMeter)
            {
                health -= healthReducer * Time.deltaTime;
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
}
