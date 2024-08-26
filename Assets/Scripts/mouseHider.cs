using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HideCursor : MonoBehaviour
{

    public InputAction escape;
    public InputAction click;

    private void OnEnable()
    {
        escape.Enable();
        click.Enable();
    }
    private void OnDisable()
    {
        escape.Disable();
        click.Disable();   
    }
    void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (escape.triggered)
        {
            Cursor.visible = true;
        }

        if (click.triggered)
        {
            Cursor.visible = false;
        }

    }
}
