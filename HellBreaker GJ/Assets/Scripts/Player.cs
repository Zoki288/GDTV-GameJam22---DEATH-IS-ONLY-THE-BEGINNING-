using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    public Controls playerControls = new Controls();
    [SerializeField] Rigidbody2D rb;
 /*
    private void Start()
    {
        playerControls.Player.Shoot.performed += context => Shoot(context);
        playerControls.Player.Move.performed += moveContext => Move(moveContext.ReadValue<Vector2>());
    }
    
    */

    public void Move(Vector2 moveDirection)
    {
        Debug.Log(moveDirection);

        Vector3 movement = new Vector3();
        movement.x = moveDirection.x;
        movement.y = 0;
        movement.z = moveDirection.y;

        rb.transform.Translate(movement * Time.deltaTime);

    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            return;
        }
        Debug.Log("We shot!");
    }
    /*
    private void OnEnable()
    {
        playerControls.Enable();
    }
    private void OnDisable()
    {
        playerControls.Disable();
    }
    */
}
