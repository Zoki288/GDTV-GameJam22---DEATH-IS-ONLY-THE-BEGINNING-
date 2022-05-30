using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int health = 100;
    public float time = 30;
    public int money;
    public int ammo = 10;
    public int damage = 5;
  
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI ammoText;
    [SerializeField] TextMeshProUGUI timeText;
    //[SerializeField] GameObject playerObject;
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

    


    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameManager>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

    }



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = "Ammo: " + ammo.ToString();
        healthText.text = "Health: " + health.ToString();
        if (Input.GetKeyDown(KeyCode.Escape))
        { SceneManager.LoadScene(0);
            Destroy(gameObject);
        }
        if (SceneManager.GetActiveScene().buildIndex == 1 )
        {
            timeText.text = Mathf.RoundToInt(time).ToString();
            time -= Time.deltaTime;
            if (time<=0)
            {
                overWorldDeath();
            }
        }
        else
        {
        
            timeText.text = "";
        }

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (health <= 0)
            {
                underWorldDeath();
            }
           
        }


    }


    public void overWorldDeath()
    {
       // money = 0;
        SceneManager.LoadScene(2);
    }

    public void underWorldDeath()
    {
        maxHealth = 100;
        time = 100;
        health = maxHealth;
        //ammo = 10;
        SceneManager.LoadScene(1);
    }
    public void shopLeft()
    {
       // money = 0;
        health = maxHealth;
        SceneManager.LoadScene(1);
    }
}
