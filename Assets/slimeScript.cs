using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeScript : MonoBehaviour
{
    public float moveSpeed = 10f;
    public GameObject player;
    public LayerMask obstacleLayer;
    public float moveInterval = 7f;
    public float attackInterval = 10f;
    public Rigidbody2D rb;

    private float attackTimer = 0f;
    private float moveTimer = 0f;
    private Vector2 moveDirection;
    private bool canSeePlayer;

    
    void Update()
    {
        seePlayer();

        if (moveTimer <= moveInterval)
        {
            Move();
            moveTimer = 0f;
            
        }

        if (attackTimer <= attackInterval)
        {
            Attack();
            attackTimer = 0f;   
        }



        attackTimer += Time.deltaTime;
        moveTimer += Time.deltaTime;
    }

    private void ChooseRandomDirection()
    {
        float randomAngle = Random.Range(0f, 360f);
        moveDirection = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle)).normalized;
    }


    private void Move()
    {
        if (canSeePlayer == false)
        {
            Roam();
        } else
        {
            Approach();
        }
        

    }
    private void Roam()
    {
       ChooseRandomDirection();
        Vector2 direction = (moveDirection - new Vector2(transform.position.x, transform.position.y)).normalized;
        rb.velocity = direction * moveSpeed;
    }

    private void Approach()
    {
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }

    private void Attack()
    {
        
    }
    public void seePlayer()
    {
        Vector2 directionToPlayer = (player.transform.position - transform.position).normalized;
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, distanceToPlayer, obstacleLayer);
        
        if (hit.collider == null)
        {
            canSeePlayer = true;
            
        }
        else
        {
            canSeePlayer = false;
            
        }
    }
}
