using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groomingtool : MonoBehaviour
{
    public float moveSpeed = 5f;
    private bool isDragging = false;
    private Vector2 offset;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = GetMouseWorldPosition();
            if (IsMouseOverGroomingTool(mousePosition))
            {
                offset = (Vector2)transform.position - mousePosition;
                isDragging = true;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
        if (isDragging)
        {
            Vector2 targetPosition = GetMouseWorldPosition() + offset;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }
    private bool IsMouseOverGroomingTool (Vector2 mousePosition)
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
