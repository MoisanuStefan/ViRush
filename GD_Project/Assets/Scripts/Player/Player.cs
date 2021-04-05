using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;

    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    public Camera cam;

    private bool isMoving;
    private bool isDamageable;

    Vector2 movement;
    Vector2 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        isDamageable = true;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isDamageable)
        {
            currentHealth -= damage;

            if (currentHealth <= 0)
            {
                animator.SetTrigger("Dead");
            }
        }

    }

    public void SetDamageable(bool value)
    {
        isDamageable = value;
    }
    public void onDeadAnimationFinished()
    {
        FindObjectOfType<GameManager>().EndGame();
        Destroy(gameObject);
        gameObject.SetActive(false);
    }
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

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        //Movement handled here
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

    }
}
