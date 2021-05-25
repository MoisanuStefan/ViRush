using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    public int damage = 50;
    private bool isFlipped = false;
    private Rigidbody2D rb;
    private EnemySpawner spawner; 
    
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        isFlipped = false;
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    private void Update()
    {
        CheckLookDirection();
    }

    private void CheckLookDirection()
    {
        if (!isFlipped && rb.velocity.x < 0 || isFlipped && rb.velocity.x > 0)
        {
            isFlipped = !isFlipped;
            Flip();
        }
    }

    private void Flip()
    {
        transform.Rotate(0, 180, 0);
    }
    public void TakeDamage(int damage)
    {   currentHealth -= damage;
        StartCoroutine("FlashSprite");
        if (currentHealth <= 0)
        {
            spawner.DecreaseVirusCount();
            Destroy(gameObject);
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
      

        }
    }

    public void SetSpawner(EnemySpawner spawner)
    {
        this.spawner = spawner;
    }

   
 
    
    
}
