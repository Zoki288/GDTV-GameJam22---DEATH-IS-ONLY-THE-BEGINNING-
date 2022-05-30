using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Items : MonoBehaviour
{


        [SerializeField] int moneyCost = 0;
    [SerializeField] int playerCash;
    [SerializeField] Controls playerControls;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (moneyCost == 0)
        {
            PickMeUp();
        }
        if (moneyCost > playerCash && playerControls.Player.Move.IsPressed())
        {
            playerCash -= moneyCost;
            PickMeUp();
        }

    }


    private void PickMeUp()
    {
        throw new NotImplementedException();
    }
}
