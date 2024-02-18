using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

 
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    public void SelectTool(string toolType)
    {
        switch (toolType)
        {
            case "blowdryer":
                // Handle blow dryer selection logic
                Debug.Log("blowdryer selected!");
                break;
            case "showerhead":
                // Handle shower head selection logic
                Debug.Log("showerhead selected!");
                break;
            default:
                Debug.LogWarning("Unknown tool type: " + toolType);
                break;
        }
        Debug.Log("Selected tool: " + toolType);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
