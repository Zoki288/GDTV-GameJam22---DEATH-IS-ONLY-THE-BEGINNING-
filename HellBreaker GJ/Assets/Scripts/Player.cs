using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float movement_speed = 8f;
    Controls playerControls;
    [SerializeField] Rigidbody2D rb;

    private void Awake()
    {
         playerControls = new Controls();
        playerControls.Player.Enable();
        playerControls.Player.Shoot.performed += Shoot;
        playerControls.Player.Sword.performed += Sword;
        playerControls.Player.Action.performed += Action;
    }

    private void FixedUpdate()
    {
        Vector2 input_vector = playerControls.Player.Move.ReadValue<Vector2>();
        Vector3 movement = new Vector3();
        movement.x = input_vector.x;
        movement.y = input_vector.y;
        movement.z = 0;
        rb.transform.Translate(movement * Time.deltaTime * movement_speed);
    }


    public void Shoot(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("We shot!");
        }
        
    }
    public void Sword(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Swish swash!");
        }

    }
    public void Action(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Ayo action!");
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
