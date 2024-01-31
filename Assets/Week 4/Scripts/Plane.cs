using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public List<Vector2> points;
    public float newPointthreshold = 0.2f;
    Vector2 lastPosition;
    LineRenderer Trailpath;
    Vector2 currentPosition;
    Rigidbody2D rigidbody;
    public float speed = 1;
    public AnimationCurve landing;
    float landingTimer;
    void OnMouseDown()
    {
        points = new List<Vector2>();


        Trailpath.positionCount = 1;
        Trailpath.SetPosition(0,transform.position);    
        

    }

    void OnMouseDrag()
    {
        Vector2 currentPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(currentPosition, lastPosition) >= newPointthreshold)
        {
            points.Add(currentPosition);
            Trailpath.positionCount++;
            Trailpath . SetPosition(Trailpath.positionCount-1, currentPosition);
            lastPosition = currentPosition;

        }

    }
    private void Start()
    {
        Trailpath = GetComponent<LineRenderer>();
        Trailpath.positionCount = 1;
        Trailpath.SetPosition(0,transform.position);
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        currentPosition = new Vector2 (transform.position.x, transform.position.y);
        if(points.Count > 0 )
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            rigidbody.rotation = -angle;

        }
        rigidbody.MovePosition(rigidbody.position + (Vector2)transform.up*speed*Time.deltaTime);
    }

    private void Update()
    {
        if (points.Count > 0 )
        {
            if(Input.GetKey(KeyCode.Space)) 
            {
                landingTimer += 0.1f * Time.deltaTime;
                float interpolation = landing.Evaluate(landingTimer);
                if (transform.localScale.x < 0f)
                {
                    Destroy(gameObject);
                }
                transform.localScale = Vector3.Lerp (transform.localScale, Vector3.zero, interpolation);
            }

            if(Vector2.Distance(currentPosition, points[0]) <newPointthreshold)
            {
                points.RemoveAt(0);
                for (int i = 0; i < Trailpath.positionCount - 2; i++)
                {
                    Trailpath.SetPosition (i, Trailpath.GetPosition(i + 1));
                }
                Trailpath.positionCount--;
            }
        }
    }
}
