using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyPlayer : MonoBehaviour
{

    Rigidbody2D rb2d;
    Animator animator;
    float x;
    float y;
    float speed = 3f;
    public enum DIRECTION
    {
        STOP,
        UP,
        DOWN,
        RIGHT,
        LEFT
    }

    DIRECTION direction = DIRECTION.STOP;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");
        
        
        if(x == 0 && y == 0)
        {
            direction = DIRECTION.STOP;
        }
        else if( x > 0 && y == 0)
        {
            direction = DIRECTION.RIGHT;
        }
        else if(x < 0 && y == 0)
        {
            direction = DIRECTION.LEFT;
        }else if(y > 0 && x == 0)
        {
            direction = DIRECTION.UP;
        }else if(y < 0 && x == 0)
        {
            direction = DIRECTION.DOWN;
        }
    }

    private void FixedUpdate()
    {
        switch (direction)
        {
            case DIRECTION.STOP:
                rb2d.velocity = new Vector2(0f, 0f);
                break;
            case DIRECTION.UP:
                rb2d.velocity = new Vector2(rb2d.velocity.x, speed);
                animator.SetTrigger("Up");
                break;
            case DIRECTION.DOWN:
                rb2d.velocity = new Vector2(rb2d.velocity.x, -speed);
                animator.SetTrigger("Down");
                break;
            case DIRECTION.RIGHT:
                transform.localScale = new Vector3(1, 1, 1);
                rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
                animator.SetTrigger("Side");
                break;
            case DIRECTION.LEFT:
                transform.localScale = new Vector3(-1, 1, 1);
                rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
                animator.SetTrigger("Side");

                break;
        }
    }
}
