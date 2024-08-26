using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curvedBulletScript : MonoBehaviour
{
    public float bulletSpeed = 5f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = transform.right * bulletSpeed;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle") || collision.CompareTag("Player"))
        {
            Destroy(gameObject);

        }
    }
}

   

