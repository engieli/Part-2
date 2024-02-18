using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groomingtool : MonoBehaviour
{
    public GameObject showerheadPrefab;
    public GameObject blowdryerPrefab;

    private string selectedToolType;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerCurrentRaycast.gameObject.name == "showerhead")
        {
            selectedToolType = "showerhead";
        }
        else if (eventData.pointerCurrentRaycast.gameObject.name == "blowdryerButton")
        {
            selectedToolType = "blowdryer";
        }
    }

    void Update()
    {
        if (selectedToolType != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f;
                if (mousePosition != null)
                {
                    GameObject groomingToolPrefab = null;

                    switch (selectedToolType)
                    {
                        case "showerhead":
                            groomingToolPrefab = showerheadPrefab;
                            break;
                        case "blowdryer":
                            groomingToolPrefab = blowdryerPrefab;
                            break;
                    }

                    if (groomingToolPrefab != null)
                    {
                        Instantiate(groomingToolPrefab, mousePosition, Quaternion.identity);
                    }

                    selectedToolType = null;


                }
            }

        }

    }      
            
        
}
