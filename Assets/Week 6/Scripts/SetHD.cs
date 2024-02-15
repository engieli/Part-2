using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetHD : MonoBehaviour
{
   public void SetFullHD()
    {
        Screen.SetResolution(1920, 1080, true);
    }
}
