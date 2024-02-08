using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour

{
    public float speed = 5f;
    public float damage = 1f;
    public float lifespan = 5f;
    public bool isMoving = true;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
        if (isMoving)
            {
        
            rb.velocity = transform.right * speed;
        
            }
        Destroy(gameObject, lifespan);


    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector2 direction = new Vector2(speed * Time.deltaTime, 0);
        rb.MovePosition(rb.position + direction);

    }
    // private void Update()
    // {
    //    transform.Translate(speed * Time.deltaTime, 0, 0);

    //  }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("knight"))
        {
            Debug.Log("Collision with Knight detected.");
            collision.gameObject.SendMessage("TakeDamage", damage);
        }
        Destroy(gameObject);
    }

}
