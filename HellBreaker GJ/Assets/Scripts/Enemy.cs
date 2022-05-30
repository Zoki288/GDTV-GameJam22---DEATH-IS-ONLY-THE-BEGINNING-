using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health;
    [SerializeField] float speed;
    [SerializeField] int damage;
    [SerializeField] float attackCooldown = 1f;
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject playerObject;
    Rigidbody2D rb;


    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            if (attackCooldown <=0)
            {
                gameManager.health -= damage;
                attackCooldown = 1f;
            }
            
        }
    }


    // Start is called before the first frame update
    void Start()
    {
         gameManager = FindObjectOfType<GameManager>();
       // playerObject = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position,playerObject.transform.position) < 15 )
        {
            rb.transform.Translate(Vector2.MoveTowards(transform.position, playerObject.transform.position, speed * Time.deltaTime));
        }

        if (attackCooldown > 0)
        {
            attackCooldown -= Time.deltaTime;
        }

        if (health <= 0)
        {


            Destroy(gameObject);
        }
    }
}
