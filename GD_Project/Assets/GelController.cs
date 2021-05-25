using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GelController : MonoBehaviour
{
    public Player player;
    public int healAmount;
    public Animator animator;
    private bool isActive = true;

    private void Start()
    {
        isActive = true;
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isActive && collision.gameObject.CompareTag("Player") && !player.IsMaxHealth())
        {
            isActive = false;
            player.Heal(healAmount);
            animator.SetTrigger("recharge");
        }
    }
   

    public void OnAnimationFinished()
    {
        isActive = true;
    }
}
