using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMove : MonoBehaviour
{
    public Transform cursor;
    public Rigidbody2D rb;
   
    private new Renderer renderer;
    private Vector2 cursorLoc;
    public float bulletSpeed = 10f;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        cursor = GameObject.FindGameObjectWithTag("Cursor").transform;
        cursorLoc = cursor.position;
        RotateTowardsCursor();
        



        Vector2 direction = (cursorLoc - rb.position).normalized;


        rb.velocity = direction * bulletSpeed;
    }
    private void RotateTowardsCursor()
    {
        Vector2 direction = cursorLoc - rb.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle; //shoutout chatgpt for mathf.atan no idea what that means
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") || collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
