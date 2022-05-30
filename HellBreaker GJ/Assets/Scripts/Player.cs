using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float movement_speed = 10f;
    Controls playerControls;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] GameObject gunRotation;
    [SerializeField] Camera mainCamera;
    Vector2 mousePosition;
    float angle;
    float wobbleAngle = 0;
    Vector3 baseScale;
    [SerializeField] GameObject playerSprite;
    [SerializeField] GameObject gunSprite;

    private void Awake()
    {
        baseScale = playerSprite.transform.localScale;
        playerControls = new Controls();
        playerControls.Player.Enable();
        playerControls.Player.Shoot.performed += Shoot;
        playerControls.Player.Sword.performed += Sword;
        playerControls.Player.Action.performed += Action;
    }

    private void Update()
    {

        Vector3 dirScale = baseScale;
        //NOTE: Unity uses angles from 180 to -180
        if (angle > 90 || angle <-90)
        {
            dirScale.x = -baseScale.x;
            playerSprite.GetComponent<SpriteRenderer>().flipX = true;
            gunSprite.GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            dirScale.x = baseScale.x;
            playerSprite.GetComponent<SpriteRenderer>().flipX = false;
            gunSprite.GetComponent<SpriteRenderer>().flipY = false;
        }
        if (playerControls.Player.Move.IsPressed())
        {

            wobbleAngle = (float)(Mathf.Sin(Time.time*10) * 10);
        }
        else
        {
          wobbleAngle = 0;
        }

        playerSprite.transform.rotation = Quaternion.Euler(0, 0, playerSprite.transform.rotation.z + wobbleAngle);
    }

    private void FixedUpdate()
    {
        mousePosition = mainCamera.ScreenToWorldPoint(playerControls.Player.Aim.ReadValue<Vector2>());
        Vector2 gunRotationPosition = new Vector2(gunRotation.transform.position.x, gunRotation.transform.position.y);
        Vector2 lookDir = mousePosition - gunRotationPosition;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg ;
        gunRotation.transform.rotation = Quaternion.Euler(0,0,angle);

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
