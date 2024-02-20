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
        }
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
