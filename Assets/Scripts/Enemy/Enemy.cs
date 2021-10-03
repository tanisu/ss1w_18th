using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb2d;

    [SerializeField]
    private float moveSpeed, waitTime, walkTime;

    private float waitCounter,moveCounter;

    private Vector2 moveDir;

    [SerializeField]
    private BoxCollider2D area;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        waitCounter = waitTime;


    }

    // Update is called once per frame
    void Update()
    {
        if(waitCounter > 0)
        {
            waitCounter -= Time.deltaTime;
            rb2d.velocity = Vector2.zero;

            if (waitCounter <= 0)
            {
                moveCounter = walkTime;

                moveDir = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
                moveDir.Normalize();
            }
        }
        else
        {
            moveCounter -= Time.deltaTime;
            rb2d.velocity = moveDir * moveSpeed;
            if(moveCounter <= 0)
            {
                waitCounter = waitTime;
            }
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, area.bounds.min.x + 1, area.bounds.max.x - 1),
            Mathf.Clamp(transform.position.y, area.bounds.min.y + 1, area.bounds.max.y - 1), transform.position.z
            );
    }
}
