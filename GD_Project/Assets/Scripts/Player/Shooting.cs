 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject[] weapon;
    public float attackRate = 2f;
    float nextAttackTime = 0f;
    int currentWeapon;

    public float bulletForce=20f;

    private void Start()
    {
        currentWeapon = 0;
    }

 
    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {

            if (Input.GetButton("Fire1"))
            {
                Shoot();
                nextAttackTime = Time.time + 1 / attackRate;
            }
           
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentWeapon = 1;
        }
    }

    void Shoot()
    {
        GameObject bullet= Instantiate(weapon[currentWeapon], firePoint.position,firePoint.rotation);
        Rigidbody2D rb=bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up*bulletForce, ForceMode2D.Impulse);

    }
}
