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

    void Update()
    {
        // Calculate the distance between the blow dryer and the cat
        float distance = Vector2.Distance(transform.position, blowDryer.transform.position);

        // Check if the blow dryer is near the cat
        if (distance <= triggerDistance)
        {
            // Set the animator parameters based on the proximity of the blow dryer
            animator.SetBool("IsBlowingDry", true);
            animator.SetBool("Drenched", false);
        }
        else
        {
            // Reset the animator parameters if the blow dryer is not near the cat
            animator.SetBool("IsBlowingDry", false);
            animator.SetBool("Drenched", true);
        }
    }
}
