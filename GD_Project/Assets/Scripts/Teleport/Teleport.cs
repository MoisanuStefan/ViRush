using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Teleport otherTeleport;
    public float speed;
    public float cooldownTime;
    public bool isActive = true;
    public bool isDisabled = false;


    private bool isTriggered;
    private Rigidbody2D rb;
    private Player player;
    private float cooldownBegin = -Mathf.Infinity;

    // Start is called before the first frame update
    void Start()
    {
        isDisabled = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered && !isDisabled)
        {
            float step = speed * Time.deltaTime; // calculate distance to move
            player.transform.position = Vector3.MoveTowards(player.transform.position, otherTeleport.transform.position, step);

            if (Vector2.Distance(player.transform.position, otherTeleport.transform.position) < 0.001f)
            {
                player.SetDamageable(true);
                otherTeleport.isActive = true;
                player.transform.position = otherTeleport.transform.position;
                isTriggered = false;
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isDisabled && isActive && Time.time > cooldownBegin + cooldownTime)
        {
            player = collision.gameObject.GetComponent<Player>();
            player.SetDamageable(false);
            otherTeleport.isActive = false;
            otherTeleport.cooldownBegin = Time.time;
            isTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isDisabled)
        {
            isActive = true;
        }
    }

    public void SetDisabledValue(bool value)
    {
        isDisabled = value;
        GetComponent<SpriteRenderer>().enabled = !value;
    }
}
