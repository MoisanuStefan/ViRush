using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public Transform[] points;
    public int playArea = -1;


    private float[,] coords_x = { { -32f, -16f }, { -10f, 5.7f }, { 12f, 27f }, { 12f, 27f }, { -32f, -16f } };
    private float[,] coords_y = { { 6f, 18f }, { -5.6f, 6.2f }, { 6f, 18f }, {-6f, -12.5f }, { -6f, -12.5f } };
    private Vector3 direction;

    int current;
    Vector3 destination;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        direction = Random.insideUnitCircle.normalized;
        rb.velocity = direction * moveSpeed;
        /*
        while (playArea == -1) ;
        float randX = Random.Range(coords_x[playArea, 0], coords_x[playArea, 1]);
        float randY = Random.Range(coords_y[playArea, 0], coords_y[playArea, 1]);
        destination = new Vector3(randX, randY, 0);
        */
    }


    private void FixedUpdate()
    {
        Move();
        /*
        if(transform.position != destination)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination, moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            float randX = Random.Range(coords_x[playArea, 0], coords_x[playArea, 1]);
            float randY = Random.Range(coords_y[playArea, 0], coords_y[playArea, 1]);
            destination = new Vector3(randX, randY, 0);
        }
        */
        /*if (transform.position != points[current].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[current].position, moveSpeed * Time.fixedDeltaTime);
        }
        else
        {
            Debug.Log(current);
            current = (current + 1) % points.Length;
        }*/
    }

    private void Move()
    {
        
    }
    /*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        direction = Random.insideUnitCircle.normalized;
        rb.velocity = direction * moveSpeed;
    }
    */

}