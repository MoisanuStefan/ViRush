using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class FenceController : MonoBehaviour
{
    float clicked = 0;
    float clicktime = 0;
    float clickdelay = 0.5f;
    public int lives = 3;
    private Player playerController;

    private void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clicked++;
            if (clicked == 1) clicktime = Time.time;

            if (clicked > 1 && Time.time - clicktime < clickdelay)
            {
                clicked = 0;
                clicktime = 0;
                transform.Rotate(0, 0, 90);

            }
            else if (clicked > 2 || Time.time - clicktime > 1) clicked = 0;

        }
        else if (Input.GetMouseButtonDown(1))
        {
            playerController.RestoreFence();
            Destroy(gameObject);
        }
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Projectile")) {
            lives--;
            if (lives == 0)
            {
                Destroy(gameObject);
            }
        
        }
    }
}
