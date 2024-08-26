using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class cameraFollow : MonoBehaviour
{
    public Transform character;
    public float cameraSpeed = 5f;
    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player").transform;
    }

    
    void Update()
    {
        float posX = character.position.x;
        float posY = character.position.y;
        float posZ = -1;

        Vector3 direction = Vector3.zero;
        direction = new Vector3 (posX, posY, posZ);
        transform.position = Vector3.Lerp(transform.position, direction, cameraSpeed * Time.deltaTime);
    }
}
