using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public Transform[] points;
    public int playArea;


    private float[,] coords_x = { { -32f, -16f }, { -9f, 4.5f } };
    private float[,] coords_y = { { 6f, 18f }, { -3.5f, 4f } };


    int current;
    Vector3 destination;
    private void Start()
    {
        float randX = Random.Range(coords_x[playArea, 0], coords_x[playArea, 1]);
        float randY = Random.Range(coords_y[playArea, 0], coords_y[playArea, 1]);
        destination = new Vector3(randX, randY, 0);
    }

    private void FixedUpdate()
    {
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

   

}