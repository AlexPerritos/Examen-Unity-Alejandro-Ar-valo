using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHealth = 3;
    private int currenthealth = 3;
    private Animator animator;
    public Rigidbody2D rb;

    private GameObject playerObj = null;


    public float speed = 3;



    private void Start()
    {
        animator = GetComponent<Animator>();
        currenthealth = 3;

        if (playerObj == null)
            playerObj = GameObject.Find("Player");
    }

    private void FixedUpdate()
    {

        ChasePlayer();

    }

    private void ChasePlayer()
    {
        if (transform.position.x < playerObj.transform.position.x)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }

       
    }

    public void TakeDamage(int damage)
    {

        currenthealth -= damage;
        if (currenthealth == 0)
        {
            EnemyDie();
        }

    }



    private void EnemyDie()
    {
        animator.SetTrigger("Die");
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        GetComponent<BoxCollider2D>().enabled = false;
        this.enabled = false;

        
    }
    
}
