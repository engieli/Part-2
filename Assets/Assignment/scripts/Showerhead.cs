using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Showerhead : MonoBehaviour
{
    public Transform cat;
    public float drenchDistance = 1.0f;

    private Animator catAnimator;

    public float moveSpeed = 5f;
    private bool isDragging = false;
    private Vector2 offset;

    void Start()
    {
        catAnimator = cat.GetComponent<Animator>();
    }

    void Update()
    {
        // Check if the player is dragging the showerhead
        if (Input.GetMouseButton(0))
        {
            Vector2 mousePosition = GetMouseWorldPosition();
            if (IsMouseOverGroomingTool(mousePosition))
            {
                offset = (Vector2)transform.position - mousePosition;
                isDragging = true;
            }
        }
        else
        {
            isDragging = false;
        }

        // Move the showerhead while the player is dragging it
        if (isDragging)
        {
            Vector2 targetPosition = GetMouseWorldPosition() + offset;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }

        // Calculate the distance between the cat and the showerhead
        float distance = Vector3.Distance(cat.position, transform.position);

        // Check if the showerhead is near the cat
        if (distance < drenchDistance)
        {
            // Trigger the cat animator to the drenched state
            catAnimator.SetBool("Drenched", true);
        }
        else
        {
            catAnimator.SetBool("Drenched", false);
        }
    }

    private bool IsMouseOverGroomingTool(Vector2 mousePosition)
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
