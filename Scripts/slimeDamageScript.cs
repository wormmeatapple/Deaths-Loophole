using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeDamageScript : MonoBehaviour
{

    public Rigidbody2D rb;

    private void Start()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PBullet"))
        {
            Vector2 collisionPoint = collision.contacts[0].point;
            takeKnockback(collisionPoint, 10);
            Debug.Log("should be doing something");
        }
    }

    private void takeKnockback(Vector2 collisionPoint, float knockbackForce)
    {
        Vector2 collision = new Vector2(collisionPoint.x, collisionPoint.y);
        Vector2 location = new Vector2(transform.position.x, transform.position.y); 

        Vector2 collisionDirection = (location - collision).normalized;
        Vector2 knockbackDirection = -collisionDirection;

        rb.velocity = knockbackDirection * knockbackForce;
    }
}
