using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int health = 100;
    public int time = 100;
    public int money;
    public int ammo;
    public int damage = 5;

    void addMoney(int x) 
    { money += x; }

    void loseMoney(int x)
    { money -= x; }

    void addHealth(int x)
    { health += x; }

    void loseHealth(int x)
    { health -= x; }

    void addMaxHealth(int x)
    { maxHealth += x; }

    void addDamage(int x)
    { damage += x; }

    void addAmmo(int x)
    { ammo += x; }

    [SerializeField] GameObject playerObject;


        
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void overWorldDeath()
    {
        money = 0;
       
    }

    public void underWorldDeath()
    {
        maxHealth = 100;
        time = 100;
        ammo = 10;
    }
    public void shopLeft()
    {
        money = 0;
        health = maxHealth;
    }
}
