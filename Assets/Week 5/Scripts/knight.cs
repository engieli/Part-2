using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class knight : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    Vector2 destination;
    Vector2 movement;
    public float speed = 3;
    bool clickingOnSelf = false;
    public float health;
    public float maxHealth = 5;
    bool isDead;
    public HeathBar healthbar;
   // public FLoat Text healthbar;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        // health = maxHealth;
      //  health.Text = PlayerPrefs.GetFloat(knight.health, 0).
            isDead = false;
    }
    private void FixedUpdate()
    {
        if (isDead) return;
        movement = destination - (Vector2)transform.position;
        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }
        rb.MovePosition(rb.position + movement.normalized * speed * Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        if (isDead) return;
        if (Input.GetMouseButtonDown(0) && !clickingOnSelf &&!EventSystem.current.IsPointerOverGameObject())
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        animator.SetFloat ("Movement", movement.magnitude);

        if(Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Attack");
        }
    }
    private void OnMouseDown()
    {
        if (isDead) return;
        clickingOnSelf =true;
        gameObject.SendMessage("TakeDamage", 1);
        //TakeDamage(1);
        //healthbar.TakeDamage(1);
       
    }
    private void OnMouseUp()
    {
        clickingOnSelf=false;

    }
   public void TakeDamage( float damage)
    {
        health -= damage;
        health = Mathf.Clamp (health, 0, maxHealth);
        if (health <= 0)
        {
            isDead=true;
            animator.SetTrigger("Death");
        }
        else
        {
            isDead = false;
            animator.SetTrigger("TakeDamage");
        }

        
    }
}
