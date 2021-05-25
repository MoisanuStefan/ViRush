using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(damage);
        }
        if (collision.gameObject.tag.Equals("ShootingEnemy"))
        {
            collision.gameObject.GetComponent<ShootingEnemy>().TakeDamage(damage);
        }

        Destroy(gameObject);
    }
   

    
}
