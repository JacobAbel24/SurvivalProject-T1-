using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystemUI : MonoBehaviour
{

    public Slider slider1, slider2, slider3;
    public Gradient gradient;
    public Image image;

    public void SetHealth(float health)
    {
        slider1.value = health;
        image.color = gradient.Evaluate(slider1.normalizedValue);
    }

    public void SetMaxHealth(float health)
    {
        slider1.maxValue = health;
        slider1.value = health;
        image.color = gradient.Evaluate(slider1.normalizedValue);
    }

    public void SetHunger(float hunger)
    {
        slider2.value = hunger;
    }

    public void SetMaxHunger(float hunger)
    {
        slider2.maxValue = hunger;
        slider2.value = hunger;
    }

    public void SetThirst(float thirst)
    {
        slider3.value = thirst;      
    }

    public void SetMaxThirst(float thirst)
    {
        slider3.maxValue = thirst;
        slider3.value = thirst;
    }

}
