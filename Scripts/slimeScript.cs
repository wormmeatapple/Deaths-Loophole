using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slimeScript : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Transform player;
    public GameObject curvedBullet;
    public LayerMask obstacleLayer;
    public float moveInterval = 7f;
    public float pauseDuration = 1f;
    public float attackInterval = 10f;
    public float radius = 5f;
    public float bulletSpeed;
    


    private float attackTimer = 0f;
    private float moveTimer = 0f;
    private Vector2 moveDirection;
    private bool canSeePlayer;
    private float moveTime = 0f;

    
    void Start()
    {
        StartCoroutine(moveAndWait());
        GameObject curvedBullet = GetComponent<GameObject>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }
    void Update()
    {
        seePlayer();

        if (attackTimer >= attackInterval)
        {
            Attack();
            attackTimer = 0f;   
        }



        attackTimer += Time.deltaTime;
    }

    private IEnumerator moveAndWait()
    {
        while (true)
        {
            moveTime = 0f;
            while (moveTime < moveInterval)
            {
                Move();
                moveTime += Time.deltaTime;
                yield return null;
            }

            yield return new WaitForSeconds(pauseDuration);
        }
    }

    private void chooseRandomDirection()
    {
        float randomAngle = Random.Range(0f, 360f);
        moveDirection = new Vector2(Mathf.Cos(randomAngle * Mathf.Deg2Rad), Mathf.Sin(randomAngle * Mathf.Deg2Rad)).normalized;
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
        if (moveTimer >= moveInterval || moveDirection == Vector2.zero)
        {
            chooseRandomDirection();
            moveTimer = 0f;
        }

        Vector2 currentPosition = transform.position;
        Vector2 targetPosition = currentPosition + moveDirection;
        Vector2 direction = Vector2.MoveTowards(currentPosition, targetPosition, moveSpeed * Time.deltaTime);
        transform.position = direction;
        moveTimer += Time.deltaTime;
    }

    private void Approach()
    {
        Vector2 currentPosition = transform.position;
        Vector2 playerPosition = player.transform.position;
        Vector2 direction = Vector2.MoveTowards(currentPosition, playerPosition, moveSpeed * Time.deltaTime);
        transform.position = direction;
        
    }

    private void Attack()
    {
        spawnBulletsInCircle(8);
        
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

    private void spawnBulletsInCircle(int numberOfBullets)
    {
        float angleStep = 360f / numberOfBullets;
        float angle = 0f;

        for (int i = 0; i < numberOfBullets; i++)
        {
            float bulletX = transform.position.x + Mathf.Cos(angle * Mathf.Deg2Rad) * radius;
            float bulletY = transform.position.y + Mathf.Sin(angle * Mathf.Deg2Rad) * radius;
            Vector3 bulletPosition = new Vector3(bulletX, bulletY, transform.position.z);

            Quaternion bulletRotation = Quaternion.Euler(new Vector3(0, 0, angle));

            Instantiate(curvedBullet, bulletPosition, bulletRotation);



            angle += angleStep;
        }
    }

}
