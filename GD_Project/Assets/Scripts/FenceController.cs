using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FenceController : MonoBehaviour
{
    public int lives = 3;
    private Player playerController;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            transform.Rotate(0, 0, 90);

        }
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {
            lives--;
            if (lives == 0)
            {
                playerController.RestoreFence();
                Destroy(gameObject);
            }
        
        }
    }
}
