using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blowdryer : MonoBehaviour
{
    public Transform cat;
    public float blowDistance = 1.0f; 
    public float dryingTime = 15.0f; 

    private Animator catAnimator;
    private bool isBlowdrying = false;
    private float blowTime = 0.0f;
    public float moveSpeed = 5f;
    private bool isDragging = false;
    private Vector2 offset;

  

    void Start()
    {
        catAnimator = cat.GetComponent<Animator>();
    }

    void Update()
    {
        // Check if the player is dragging the grooming tool
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePosition = GetMouseWorldPosition();
            if (IsMouseOverGroomingTool(mousePosition))
            {
                offset = (Vector2)transform.position - mousePosition;
                isDragging = true;
            }
        }
        // Release the grooming tool when the user releases the mouse button
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }
        // Move the grooming tool while the user is dragging it
        if (isDragging)
        {
            Vector2 targetPosition = GetMouseWorldPosition() + offset;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        }

        // Calculate the distance between the cat and the blowdryer
        float distance = Vector3.Distance(cat.position, transform.position);

        // Check if the blowdryer is near the cat
        if (distance < blowDistance)
        {
            // Start blowdrying the cat
            StartBlowdrying();
        }
        else
        {
            // Stop blowdrying the cat
            StopBlowdrying();
        }

        // If blowdrying, increase the blow time and check if it exceeds the drying time
        if (isBlowdrying)
        {
            blowTime += Time.deltaTime;
            if (blowTime >= dryingTime)
            {
                // Stop blowdrying after the drying time has elapsed
                StopBlowdrying();
                catAnimator.SetBool("Drenched", false);
            }
         
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

    private void StartBlowdrying()
    {
        // Set the animation parameter for the cat to indicate that it is being blow-dried
        catAnimator.SetBool("IsBlowdrying", true);
        isBlowdrying = true;
    }

    private void StopBlowdrying()
    {
        // Set the animation parameter for the cat to indicate that it is not being blow-dried
        catAnimator.SetBool("IsBlowdrying", false);
        isBlowdrying = false;
        blowTime = 0.0f;
    }
}
