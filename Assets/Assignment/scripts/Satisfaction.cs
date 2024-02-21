using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satisfaction : MonoBehaviour
{
    public Slider slider;
   // float happy = 1;

    // Method to increase satisfaction
    public void drying(float happy)
    {
        // Increase satisfaction by the 'happy' amount
        slider.value += happy;

    }
}
