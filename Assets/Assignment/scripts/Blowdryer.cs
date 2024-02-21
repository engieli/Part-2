using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blowdryer : MonoBehaviour
{

    public float moveSpeed = 5f;
    private bool isDragging = false;
    private Vector2 offset;
    private float satisfactionLevel = 0f;

    // Specify rotation angle in degrees
    public float rotationAngle = 45f;
    void Update()
    {

        // Check if the player is dragging the blow dryer
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = GetMouseWorldPosition();
            if (IsMouseOverBlowDryer(mousePosition))
            {
                offset = (Vector2)transform.position - mousePosition;
                isDragging = true;
            }
        }

        // Release the blow dryer when the user releases the mouse button
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // Move the blow dryer while the user is dragging it
        if (isDragging)
        {
            Vector2 targetPosition = GetMouseWorldPosition() + offset;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Rotate the movement direction based on the specified angle
            RotateMovementDirection(rotationAngle);
        }
    }


    //makes it look like you really picked up the blowdryer!

    private void RotateMovementDirection(float angleDegrees)
    {
       
        float angleRadians = angleDegrees * Mathf.Deg2Rad;

        
        float rotatedX = Mathf.Cos(angleRadians);
        float rotatedY = Mathf.Sin(angleRadians);

       
        Vector2 rotatedDirection = new Vector2(rotatedX, rotatedY);

   
        transform.up = rotatedDirection; 
    }

    private bool IsMouseOverBlowDryer(Vector2 mousePosition)
    {
        Collider2D hitCollider = Physics2D.OverlapPoint(mousePosition);
        return (hitCollider != null && hitCollider.gameObject == gameObject);
    }

    private Vector2 GetMouseWorldPosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }

}
