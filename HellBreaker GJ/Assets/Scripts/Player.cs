using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

   
    [SerializeField] Rigidbody2D rb;

    private void Awake()
    {
        Controls playerControls = new Controls();
        playerControls.Player.Enable();
        playerControls.Player.Shoot.performed += Shoot;
        playerControls.Player.Move.performed += moveContext => Move(moveContext.ReadValue<Vector2>());
    }
    
   

    public void Move(Vector2 moveDirection)
    {
        Debug.Log(moveDirection);

        Vector3 movement = new Vector3();
        movement.x = moveDirection.x;
        movement.y = moveDirection.y;
        movement.z = 0;

        rb.transform.Translate(movement * Time.deltaTime);

    }

    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("We shot!");
        }
        
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
