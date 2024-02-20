using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat : MonoBehaviour
{
    public Transform blowdryer;
    public Transform showerhead;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Drenched", false); 
    }

    void Update()
    {
        Vector3 directionToBlowdryer = blowdryer.position - transform.position;
        Vector3 normalizedDirection = directionToBlowdryer.normalized;

        float angleX = Mathf.Atan2(normalizedDirection.y, normalizedDirection.x) * Mathf.Rad2Deg;
        float angleY = Mathf.Atan2(normalizedDirection.x, normalizedDirection.y) * Mathf.Rad2Deg;

        animator.SetFloat("BlownX", angleX);
        animator.SetFloat("BlownY", angleY);
        animator.SetBool("IsBlowdrying", true); 
        animator.SetBool("Drenched", true); 
    }
}
