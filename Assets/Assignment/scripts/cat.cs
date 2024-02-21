using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat : MonoBehaviour
{
    public Animator animator;
    public GameObject blowDryer;
    public float triggerDistance = 1f;
    public Satisfaction satisfactionScript;
  
  
    void Update()
    {
        // Calculate the distance between the blow dryer and the cat
        float distance = Vector2.Distance(transform.position, blowDryer.transform.position);

        // Check if the blow dryer is near the cat
        if (distance <= triggerDistance)
        {

            satisfactionScript.SendMessage("drying",1);
            // Set the animator parameters based on the proximity of the blow dryer
            animator.SetBool("IsBlowingDry", true);
            animator.SetBool("Drenched", false);

            // Calculate direction from cat to blow dryer
            Vector3 direction = (blowDryer.transform.position - transform.position).normalized;

            // Calculate angle of direction relative to the cat's forward direction
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Determine the corresponding blend tree parameters based on the angle
            float x = 0f, y = 0f;
            if (angle >= -45f && angle < 45f)
            {
                x = 1f; 
            }
            else if (angle >= 45f && angle < 135f)
            {
                y = 1f; 
            }
            else if (angle >= -135f && angle < -45f)
            {
                y = -1f; 
            }
            else
            {
                x = -1f; 
            }

            // Set the blend tree parameters in the Animator
            animator.SetFloat("BlownX", x);
            animator.SetFloat("BlownY", y);
        }
        else
        {
            // Reset the animator parameters if the blow dryer is not near the cat
            animator.SetBool("IsBlowingDry", false);
            animator.SetBool("Drenched", true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == blowDryer)
        {
            satisfactionScript.SendMessage("drying", 1f);
            // Set the animator parameters based on interaction with the blow dryer
            animator.SetBool("IsBlowingDry", true);
            animator.SetBool("Drenched", false);
            Debug.Log("satisfactionScript"); 
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == blowDryer)
        {
            // Reset the animator parameters when the blow dryer exits the cat's trigger zone
            animator.SetBool("IsBlowingDry", false);
            animator.SetBool("Drenched", true);
        }
    }
}
