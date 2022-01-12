using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingController : MonoBehaviour
{
    public int maxHealth = 3;
    private int currenthealth = 3;
    private Animator animator;
    public Rigidbody2D rb;

    public Transform target;//set target from inspector instead of looking in Update
    public float speed = 3f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        currenthealth = 3;
    }

    private void FixedUpdate()
    {
        //rotate to look at the player
        transform.LookAt(target.position);
        transform.Rotate(new Vector3(0, -90, 0), Space.Self);//correcting the original rotation


        //move towards the player
        if (Vector2.Distance(transform.position, target.position) > 1f)
        {//move if distance from target is greater than 1
            transform.Translate(new Vector2(speed * Time.deltaTime, rb.velocity.y));
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
        animator.SetTrigger("die");
        rb.gravityScale = 0.5f;
        GetComponent<BoxCollider2D>().enabled = false;
        this.enabled = false;


    }

}
