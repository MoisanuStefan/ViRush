using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int damage = 50;
    public Animator animator;

    
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        StartCoroutine("FlashSprite");
        if (currentHealth <= 0)
        {
            animator.SetTrigger("dead");
        }
    }

    IEnumerator FlashSprite()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        int counter = 2;
        while (counter > 0)
        {
            sr.enabled = false;
            yield return new WaitForSeconds(0.05f);
            sr.enabled = true;
            yield return new WaitForSeconds(0.05f);
            counter--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(damage);
            animator.SetTrigger("dead");
      

        }
    }

    public void onDeathAnimationFinished()
    {
        Destroy(gameObject);
    }
 
    
    
}
