using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int maxHealth;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public GameObject game_over, Player;

    public float Timer = 3;
    public float nextHit;

    void Start()
    {
        game_over.SetActive(false);
        
    }

    void FixedUpdate()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        if (health == 0)
        {
            game_over.SetActive(true);
            Player.SetActive(false);
        }

        for (int i = 0; i < hearts.Length; i++)
        {

            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        nextHit += Time.deltaTime;


    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (nextHit > Timer)
        {
            if (col.gameObject.tag.Equals("Enemy") || (col.gameObject.tag.Equals("FlyingEnemy")) )
            {
                health -= 1;
                nextHit = 0;
            }

        }
        
    }

}
