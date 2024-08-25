using UnityEngine;
using UnityEngine.Experimental.AI;
using UnityEngine.InputSystem;

public class CursorFollow : MonoBehaviour
{
    private Vector2 mousePosition;

    public float mouseSpeed = 7.5f;
    public InputAction mouseControls;
    public GameObject bullet;
    public Transform character;


    private void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void OnEnable()
    {
        mouseControls.Enable();
    }
    private void OnDisable()
    {
        mouseControls.Disable();
    }
    void Update()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        worldPosition.z = transform.position.z;

        Vector2 charLoc = character.position;

        transform.position = Vector3.Lerp(transform.position, worldPosition, mouseSpeed * Time.deltaTime);

        if (mouseControls.triggered)
        {
            Instantiate(bullet, charLoc, transform.rotation);
            
        }
    }


}
