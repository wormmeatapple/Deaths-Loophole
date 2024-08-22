using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMove : MonoBehaviour
{
    public GameObject cursor;
    public Rigidbody2D rb;

    private Vector2 cursorLoc;
    public float bulletSpeed = 10f;

    private void Start()
    {
        getMouse();


        Vector2 direction = (cursorLoc - rb.position).normalized;


        rb.velocity = direction * bulletSpeed;
    }

    private void getMouse()
    {
        cursorLoc = cursor.transform.position;
        Debug.Log(cursorLoc);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") || collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
