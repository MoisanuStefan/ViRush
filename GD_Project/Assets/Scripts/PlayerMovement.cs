using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public Camera cam;

    private bool isMoving;

    Vector2 movement;
    Vector2 mousePos;
    // Update is called once per frame
    void Update()
    {
        // Input handled here
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x != 0 || movement.y != 0)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        animator.SetBool("isMoving", isMoving);

        mousePos= cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        //Movement handled here
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir=mousePos-rb.position;
        float angle=Mathf.Atan2(lookDir.y,lookDir.x)* Mathf.Rad2Deg-90f;
        rb.rotation=angle;

    }
}
