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
    public AnimationCurve curve;
    public float duration = 1f;
    private Vector3 startPosition;
    private Vector3 targetPosition;
    public GameObject sit;

    void Start()
    {
        startPosition = transform.position;
        targetPosition = sit.transform.position; 
        StartCoroutine(AnimateCatEntrance());
    }

    IEnumerator AnimateCatEntrance()
    {
        float startTime = Time.time;
        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            float curveValue = curve.Evaluate(t);
            transform.position = Vector3.Lerp(startPosition, targetPosition, curveValue);
            yield return null;
        }
    }

    void Update()
    {
        // Calculate the distance between the blow dryer and the cat
        float distance = Vector2.Distance(transform.position, blowDryer.transform.position);

        // Check if the blow dryer is near the cat
        if (distance <= triggerDistance)
        {
            satisfactionScript.SendMessage("drying", 1);
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
}