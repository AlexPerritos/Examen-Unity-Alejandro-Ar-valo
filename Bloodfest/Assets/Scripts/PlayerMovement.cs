using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Variables Movimiento
    public float speed = 2;
    public float jump = 3;

   

    //Referencia a los componentes del objeto
    private Rigidbody2D rb2D;

    public SpriteRenderer spriteRenderer;

    public Animator animator;

    
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
       

        //Este vector nos permite rotar el objeto del personaje
        Vector3 charecterScale = transform.localScale;

        // Movimiento horizontal
        if (Input.GetKey("d"))
        {
            //Cambiamos el vector velocidad del rigidbody
            rb2D.velocity = new Vector2(speed, rb2D.velocity.y);

            animator.SetBool("Run", true);

            //Mantenemos una rotación u otra
            charecterScale.x = 1;
        }
        else if (Input.GetKey("a"))
        {
            rb2D.velocity = new Vector2(-speed, rb2D.velocity.y);

            animator.SetBool("Run", true);

            //Mantenemos una rotación u otra
            charecterScale.x = -1;
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);
            animator.SetBool("Run", false);
        }
        //Cambio de la escala antigua a la nueva
        transform.localScale = charecterScale;

        //Salto
        if (Input.GetKey("space") && checkGround.isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jump);
        }

        if (checkGround.isGrounded==false)
        {
            animator.SetBool("Run", false);
            animator.SetBool("Jump", true);

        }

        if (checkGround.isGrounded == true)
        {
            animator.SetBool("Jump", false);
           
        }


    }
}
