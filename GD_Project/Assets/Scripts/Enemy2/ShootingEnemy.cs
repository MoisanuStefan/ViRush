using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    public int maxHealth = 100;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;
    public float nearDistance;
    public float startTimeBtwShots;
    int currentHealth;

    private float timeBtwShots;

    public GameObject projectile;
    private Transform player;

    //tag on player
    void Start (){
        currentHealth = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
    }

    void Update ()
    {
            if(Vector2.Distance(transform.position, player.position)>stoppingDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, speed*Time.deltaTime);
            }
            else if(Vector2.Distance(transform.position, player.position)<stoppingDistance && Vector2.Distance(transform.position, player.position)>retreatDistance)
            {
                transform.position=this.transform.position;
            }
            else if(Vector2.Distance(transform.position, player.position)<retreatDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, -speed*Time.deltaTime);
            }
        
        if(timeBtwShots<=0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBtwShots=startTimeBtwShots;
        }
        else{
            timeBtwShots -=Time.deltaTime;
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    //rigid body  && circle collider
}