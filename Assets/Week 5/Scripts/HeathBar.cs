using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeathBar : MonoBehaviour
{
    public Slider slider;

    public void TakeDamage(float damage)
    {
      slider.value -= damage;    
    }
}
