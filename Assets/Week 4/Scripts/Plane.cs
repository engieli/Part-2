using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    public float newPointthreshold = 0.2f;
    Vector2 lastPosition;
    LineRenderer Trailpath;

    void OnMouseDown()
    {
        points = new List<Vector2>();
        Vector2 currentPosition= Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Add(currentPosition);
        Trailpath.positionCount = 1;
        Trailpath.SetPosition(0,transform.position);    
        

    }

    void OnMouseDrag()
    {
        Vector2 currentPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(currentPosition, lastPosition) > newPointthreshold)
        {
            points.Add(currentPosition);
            Trailpath.positionCount++;

        }

    }
    private void Start()
    {
        Trailpath = GetComponent<LineRenderer>();
        Trailpath.positionCount = 1;
        Trailpath.SetPosition(0,transform.position);
        
    }
}
