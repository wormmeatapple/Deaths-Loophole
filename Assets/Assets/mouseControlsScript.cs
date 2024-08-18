using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.InputSystem;

public class CursorFollow : MonoBehaviour
{
    private Vector2 mousePosition;
    public float mouseSpeed = 7.5f;


    void Update()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldPosition.z = transform.position.z;
        transform.position = Vector3.Lerp(transform.position, worldPosition, mouseSpeed * Time.deltaTime);
    }


}
