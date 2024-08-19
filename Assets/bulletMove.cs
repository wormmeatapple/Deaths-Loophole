using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMove : MonoBehaviour
{
    public GameObject cursor;
    private Vector3 cursorLoc;
    public float bulletSpeed = 10f;

    private void Start()
    {
        cursorLoc = getCursorLoc();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, cursorLoc, bulletSpeed * Time.deltaTime);
    }

    private Vector3 getCursorLoc()
    {
        return cursor.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
