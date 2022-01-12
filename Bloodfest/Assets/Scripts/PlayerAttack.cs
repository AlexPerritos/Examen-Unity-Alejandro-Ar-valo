using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    private Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int playerDamage = 2;

    public float maxTimeAttack = 1f;
    public float nextAttack = 0f;



    private void Awake()
    {
        animator = GetComponent<Animator>();

    }
    
    private void FixedUpdate()
    {
        nextAttack += Time.deltaTime;

        if (Input.GetKey("e") && nextAttack > maxTimeAttack )
        {
            
            Attack();
            nextAttack = 0f;

        }
           
    }
    private void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            if (enemy.gameObject.tag.Equals("Enemy"))
            {
                enemy.GetComponent<EnemyController>().TakeDamage(playerDamage);
            }
            else 
            {
                enemy.GetComponent<FlyingController>().TakeDamage(playerDamage);
            }
            
        }



    }

 
}
