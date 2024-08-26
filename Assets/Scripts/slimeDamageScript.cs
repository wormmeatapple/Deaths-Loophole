using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class slimeDamageScript : MonoBehaviour
{

    public Rigidbody2D rb;
    public float knockbackForce = 1.0f;
    public Vector2 direction;

    public slimeScript slime;

    private void Start()
    {
        slimeScript slime = GetComponent<slimeScript>();
        

    }

    private void Update()
    {
        Vector2 direction = slime.direction;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PBullet"))
        {
            Vector2 collisionPoint = collision.transform.position;
            takeKnockback(collisionPoint, knockbackForce);
            
            
        }
    }

    private void takeKnockback(Vector2 collisionPoint, float knockbackForce)
    {
        Vector2 collision = new Vector2(collisionPoint.x, collisionPoint.y);
        Vector2 location = new Vector2(transform.position.x, transform.position.y); 

        Vector2 knockbackDirection = (location - collision).normalized;


        rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);

        if (direction != null)
        {
            rb.AddForce((location - direction) * knockbackDirection, ForceMode2D.Impulse);
        }

    }

    
}
